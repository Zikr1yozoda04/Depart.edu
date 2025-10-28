namespace Mavzuho.Models
{
    public class KatMavzu
    {
        public int Id { get; set; }
        public string Nomgu { get; set; } 
        public string Sharh { get; set; }
        public ICollection<Mavzu> mavzuho { get; set; } = new List<Mavzu>(); 
    }
}
