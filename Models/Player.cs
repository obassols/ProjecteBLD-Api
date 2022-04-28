using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjecteBLD.Model
{
    public class Player
    {
        [Key]
        [Column(TypeName = "varchar(15)")]
        public string username { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string password { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string email { get; set; }
    }
}