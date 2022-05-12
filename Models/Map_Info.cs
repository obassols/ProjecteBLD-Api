using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjecteBLD.Model
{
    public class Map_Info
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        public string id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string title { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string? description { get; set; }
        public byte[] icon { get; set; }
        public Player author { get; set; }
        public Map? map { get; set; }
        public ICollection<Map_Info_Player> players { get; set; }
    }
}