using Examen.Models.Base;

namespace EXAMEN.Models.Owner
{
    public class Owner : BaseEntity
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public ICollection<Dog.Dog> ? Dogs { get; set; }
    }
}
