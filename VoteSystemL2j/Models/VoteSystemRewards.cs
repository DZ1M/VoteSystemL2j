using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteSystemL2j.Models
{
    [Table("votesystem_rewards")]
    public class VoteSystemRewards
    {
        [Key]
        [Column("id")]
        public int Id{ get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }
        [Column("quantidade")]
        public int Count { get; set; }
        [Column("enchant_level")]
        public int EnchantLevel { get; set; }
        [Column("votos_por_login_de")]
        public int De { get; set; }
        [Column("votos_por_login_ate")]
        public int Ate { get; set; }
    }
}
