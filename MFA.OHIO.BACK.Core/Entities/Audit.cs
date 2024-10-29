
namespace MFA.OHIO.BACK.Core.Entities
{
    public class Audit
    {
        public int eventId { get; set; }
        public int userId {  get; set; }
        public string eventType {  get; set; }
        public DateTime fechaHoraEvento {  get; set; }
        public string eventDescription { get; set; }
    }
}
