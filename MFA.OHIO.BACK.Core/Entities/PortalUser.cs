using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Entity
{
    public class PortalUser
    {
        public int userId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string usuario {  get; set; }  
        public string password { get; set; }
        public string rol {  get; set; }
        public string status { get; set; }
        public DateTime fechaHoraCreacion { get; set; }
    }
}
