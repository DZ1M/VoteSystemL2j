using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteSystemL2j.Models
{
    [Table("votesystem_votos")]
    public class VoteSystemVotos
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("login")]
        public string Login { get; set; }
        [Column("ip")]
        public string Ip { get; set; }

        [Column("data_voto")]
        public DateTime Data { get; set; }
    }
}
