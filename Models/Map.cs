using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjecteBLD.Model
{
    public class Map
    {
        [Key]
        [Column(TypeName = "varchar(200)")]
        public string downloadlink { get; set; }
    }
}