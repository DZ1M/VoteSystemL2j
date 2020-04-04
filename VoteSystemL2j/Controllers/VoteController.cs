using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using VoteSystemL2j.Helpers;
using VoteSystemL2j.Models;
using VoteSystemL2j.Services;

namespace VoteSystemL2j.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class VoteController : Controller
    {
        public IActionResult Index()
        {
            string ip = User.Identity.GetIpUsuario();
            string login = User.Identity.GetUserId();
            if (!String.IsNullOrEmpty(ip) && !String.IsNullOrEmpty(login))
            {
                // Verifica se ja votou hoje
                if (new ConsultaService().VerificaSeJaVotou(login, ip))
                {
                    TempData["Mensagem"] = "Tente amanha, você já recebeu sua recompensa hoje !";
                    return View();
                }
                else
                {
                    ViewBag.Characters = new ConsultaService().BuscaCharactersOfflinePorLogin(login);

                    // Busca Tops e retorna para pagina
                    return View(new ConsultaService().BuscaTops());
                }
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public JsonResult Validar(int charId)
        {
            if (charId <= 0)
                return Json("Selecione um personagem!");

            string ip = User.Identity.GetIpUsuario();
            string login = User.Identity.GetUserId();

            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(ip))
                return Json("Ocorreu um erro, tente novamente!");

            var character = new ConsultaService().BuscaCharacterPorId(charId, login);
            if (character == default(Character))
                return Json("Ocorreu um erro, tente novamente!");

            // Verifica se ja nao votou e recebeu hoje
            if(new ConsultaService().VerificaSeJaVotou(login, ip))
                return Json("Você já votou hoje!!!");

            if (!String.IsNullOrEmpty(new AppConfigurationManager().TopL2jBrasil()))
            {
                var json = new VoteSystemService().VerificarL2jBrasil(ip);
                if(json.Data.ip != ip)
                    return Json("Você ainda não votou em todos os links!!!");
            }

            // Verifica se votou no mmotop, caso tiver algo na string
            if (!String.IsNullOrEmpty(new AppConfigurationManager().TopMMo()))
            {
                var json = new VoteSystemService().VerificarTopMMo(ip);     
                if (!json.Data.is_voted)
                    return Json("Você ainda nao votou em todos os links!!!");
            }

            try
            {
                // Se chegou até aqui, votou e entrega os items
                new ConsultaService().EntregaItems(login, ip, charId);

                return Json("Vote validado com sucesso! <br> Seu item se encontra na wharehouse de seu personagem: " + character.CharName);
            }
            catch
            {
                return Json("Voto não validado, tente novamente!");
            }

        }

    }
}