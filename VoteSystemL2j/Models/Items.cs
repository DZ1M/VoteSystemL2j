using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoteSystemL2j.Models
{
    [Table("items")]
    public class Items
    {
        [Key]
        [Column("object_id")]
        public int ObjectId { get; set; }

        [Column("owner_id")]
        public int OwnerId { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }

        [Column("count")]
        public int Count { get; set; }

        [Column("loc")]
        public string Loc { get; set; }

        [Column("loc_data")]
        public int LocData { get; set; }

        [Column("enchant_level")]
        public int EnchantLevel { get; set; }
        [Column("time")]
        public int Time { get; set; }
    }
}
