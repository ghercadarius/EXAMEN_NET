using Examen.Models.Base;

namespace EXAMEN.Models.Eveniment
{
    public class Eveniment : BaseEntity
    {
        public string Nume { get; set; }
        public string Locatie { get; set; }
        public string Data { get; set; }

        public ICollection<Participant.Participant> Participanti { get; set; }
    }
}
