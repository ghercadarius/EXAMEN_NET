using Examen.Models.Base;

namespace EXAMEN.Models.Participant
{
    public class Participant : BaseEntity
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public bool ?Organizator{ get; set; }

        public ICollection<Eveniment.Eveniment> Evenimente { get; set; }

    }
}
