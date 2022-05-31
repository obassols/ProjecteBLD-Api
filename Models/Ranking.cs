using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjecteBLD.Model
{
    [Serializable]
    public class Ranking
    {
        public string mapName { get; set; }
        public List<Map_Info_Player> ranking { get; set; }
    }
}