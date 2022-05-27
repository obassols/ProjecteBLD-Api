using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjecteBLD.Model
{
    public class Map_Info_Player
    {
        public bool completed { get; set; }
        public int time { get; set; }

        //FK
        public string mapInfoFK { get; set; }
        public string playerFK { get; set; }
        [JsonIgnore]
        public virtual Map_Info? mapInfo { get; set; }
        [JsonIgnore]
        public virtual Player? player {get; set; }
    }
}