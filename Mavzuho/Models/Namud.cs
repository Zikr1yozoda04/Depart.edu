namespace Mavzuho.Models
{
    public class Namud
    {
        public int Id { get; set; }
        public string Nomgu { get; set; }
        public string Sharh { get; set; }
        public ICollection <Mavzu> ICmavzu;
    }
}
