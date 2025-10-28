namespace OmuzgorServise.Model
{
    public class Daraja
    {
        public int Id { get; set; }
        public string Nomgu {  get; set; }
        public string Sharh { get; set; }
        public ICollection<Omuzgor> Omuzgoron { get; set; } = new List<Omuzgor>();
    }
}
