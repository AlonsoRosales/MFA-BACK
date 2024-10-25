using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Entities
{
    public class SystemVariables
    {
        public int ttl {  get; set; }
        public int maxFailedAttemps { get; set; }
        public int watchdogTimer { get; set; }
    }
}
