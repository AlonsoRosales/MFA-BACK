using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Entity
{
    public class Application
    {
        public string applicationId { get; set; }
        public string nombre { get;set; }
        public char status {  get; set; }
        public DateTime fechaHoraCreacion { get; set; }
        public string ipRanges {get; set; }
        public int userIdCreacion { get; set; }
        public DateTime fechaHoraModificacion { get; set; }
        public int userIdModificacion { get;set; }
    }
}
