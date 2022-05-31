using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjecteBLD.Model
{
    public class Ranking
    {
        public List<Map_Info_Player> ranking;
    }
}