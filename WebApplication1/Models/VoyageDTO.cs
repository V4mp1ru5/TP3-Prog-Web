namespace WebApplication1.Models
{
    public class VoyageDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public bool Public { get; set; }

        public List<string> UserNames { get; set; }
    }
}
