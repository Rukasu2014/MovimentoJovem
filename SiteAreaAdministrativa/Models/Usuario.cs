

namespace SiteAreaAdministrativa.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public bool aprovado  { get; set; }
    }
}