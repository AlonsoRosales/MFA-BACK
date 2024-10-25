using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Entity
{
    public class GrantedUser
    {
        public int granteduserId {  get; set; }
        public string user {  get; set; }  
        public string email { get; set; }
        public string applicationId { get; set;}
        public int userStatus { get; set; }
        public DateTime fechaHoraCreacion { get; set; }
    }
}
