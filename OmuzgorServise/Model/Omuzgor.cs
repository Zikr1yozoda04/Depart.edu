namespace OmuzgorServise.Model
{
    public class Omuzgor
    {
        public int Id { get; set; }
        public string FullName{ get; set; }
        public int  IdDaraja { get; set; }
        public int IdUnvon {  get; set; }
        public string Rasm { get; set; }
        public string Telephon { get; set; }
        public string Email { get; set; }
        public string JoiTav { get; set; }
        public string JoiZist {  get; set; }
        public int Pol {  get; set; }
        public Daraja Daraja { get; set; }
        public Unvon Unvon { get; set; }
    }

}
