using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteSystemL2j.Models
{
    [Table("votesystem_tops")]
    public class VoteSystemTops
    {
        [Key]
        [Column("id")]
        public int IdTop { get; set; }

        [Column("link_votacao")]
        public string LinkVotacao { get; set; }

        [Column("nome_top")]
        public string Nome { get; set; }

        [Column("link_imagem")]
        public string LinkImagem { get; set; }

    }
}
