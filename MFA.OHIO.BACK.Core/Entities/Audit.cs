using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Entity
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
