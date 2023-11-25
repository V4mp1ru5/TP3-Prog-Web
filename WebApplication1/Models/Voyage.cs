using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Voyage
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public bool Public { get; set; }

        [JsonIgnore]
        public virtual List<VoyageUser>? VoyageUsers { get; set; } = new List<VoyageUser>();
    }
}
