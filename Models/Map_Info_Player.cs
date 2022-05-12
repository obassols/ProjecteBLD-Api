using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjecteBLD.Model
{
    public class Map_Info_Player
    {
        public bool completed { get; set; }
        public int time { get; set; }
        public Map_Info mapInfo { get; set; }
        public Player player {get; set; }
    }
}