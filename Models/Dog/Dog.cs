using Examen.Models.Base;

namespace EXAMEN.Models.Dog
{
    public class Dog : BaseEntity
    {
        public string Nume { get; set; }
        public string Rasa { get; set; }
        public string Culoare { get; set; }

        public Guid? OwnerId { get; set; }

        public Owner.Owner Owner { get; set; }

    }
}
