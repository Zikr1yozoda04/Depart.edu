namespace Mavzuho.Models
{
    public class Mavod
    {
        public int Id { get; set; }
        public string Suroga { get; set; }
        public int IdNamud { get; }
        public int IdSohib {  get; set; }
        public int IdFan { get; set; }
        public Namud namud;
    }
}
