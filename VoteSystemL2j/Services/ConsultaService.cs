using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VoteSystemL2j.Context;
using VoteSystemL2j.Models;
using VoteSystemL2j.Models.Enums;

namespace VoteSystemL2j.Services
{
    public class ConsultaService
    {
        #region Metodos referentes ao usuario
        public Accounts BuscaPorLoginSenha(string login, string senha)
        {
            var ctx = new L2Context();
            return ctx.Accounts.Where(x => x.Login == login && x.Password == senha).AsNoTracking().FirstOrDefault();
        }
        public List<Character> BuscaCharactersOfflinePorLogin(string login)
        {
            var ctx = new L2Context();
            return ctx.Character.Where(x => x.Login == login && x.Online == Status.Offline).AsNoTracking().ToList();
        }
        public Character BuscaCharacterPorId(int charId, string login)
        {
            var ctx = new L2Context();
            return ctx.Character.Where(x => x.CharId == charId && x.Login == login).AsNoTracking().FirstOrDefault();
        }
        #endregion

        #region Metodos referentes aos votos

        public bool VerificaSeJaVotou(string login, string ip)
        {
            var ctx = new L2Context(); //
            return ctx.VoteSystemVotos.Where(x => (x.Login == login && x.Data.Day == DateTime.Today.Day && x.Data.Month == DateTime.Today.Month && x.Data.Year == DateTime.Today.Year
            || x.Ip == ip && x.Data.Day == DateTime.Today.Day && x.Data.Month == DateTime.Today.Month && x.Data.Year == DateTime.Today.Year)).AsNoTracking().Any();
        }

        public List<VoteSystemTops> BuscaTops()
        {
            var ctx = new L2Context();
            return ctx.VoteSystemTops.AsNoTracking().ToList();
        }
        #endregion
       
        #region Metodos para entrega de itens
        public int GeraNovoIdObjeto()
        {
            var ctx = new L2Context();
            return 1000 + ctx.Items.OrderByDescending(x => x.ObjectId).Take(1).AsNoTracking().FirstOrDefault().ObjectId;
        }
        public List<VoteSystemRewards> BuscaRewards(string login)
        {
            var ctx = new L2Context();
            //Usa reward por quantidade voto ?
            if (new AppConfigurationManager().RewardsPorQuantidadeVotos())
            {
                // Busca total votos player
                var totalVotos = TotalVotosLogin(login);
                // Pega reward conforme configurado o minimo e maximo
                return ctx.VoteSystemRewards.Where(x => x.De >= totalVotos && x.Ate <= totalVotos).AsNoTracking().ToList();
            }
            return ctx.VoteSystemRewards.AsNoTracking().ToList();
        }
        public int TotalVotosLogin(string login)
        {
            var ctx = new L2Context();
            return ctx.VoteSystemVotos.Where(x => x.Login.Equals(login)).Count();
        }
        public void EntregaItems(string login, string ip, int charId)
        {
            // Verifica mais uma vez se ja nao foi entregue
            if (VerificaSeJaVotou(login, ip))
                throw new Exception("Você já recebeu seu reward hoje!");

            var ctx = new L2Context();
            var novoIdItem = GeraNovoIdObjeto();
            // Busca e insere Rewards
            foreach (var obj in BuscaRewards(login))
            {
                // Entrega os items
                var item = new Items()
                {
                    ItemId = obj.ItemId,
                    Count = obj.Count,
                    EnchantLevel = obj.EnchantLevel,
                    Loc = "WAREHOUSE",
                    OwnerId = charId,
                    ObjectId = novoIdItem,
                    LocData = 0,
                    Time = -1
                };
                novoIdItem++;
                // Insere objeto
                ctx.Items.Add(item);
            }

            // Insere na tabela votesystem_votos para salvar que usuario votou no dia
            ctx.VoteSystemVotos.Add(new VoteSystemVotos()
            {
                Login = login,
                Data = DateTime.Now,
                Ip = ip
            });

            // Salva no banco todas as insercoes acima
            ctx.SaveChanges();
        }
        #endregion
    }
}
