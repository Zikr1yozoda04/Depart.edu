namespace Mavzuho.Models
{
    public class Mavzu
    {
        public int Id { get; set; }
        public string Nomgu { get; set; }
        public int  IdKatMavzu { get; set; }
        public int IdStudent { get; set; }
        public int IdOmuzgor { get; set; }
        public DateTime Sana { get; set; }
        
        public Mavod mavod;

    }
}
