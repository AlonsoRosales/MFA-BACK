using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Entity
{
    public class Token
    {
        public int tokenId {  get; set; }
        public string token {  get; set; }
        public int grantedUserId {get; set; }
        public char status {  get; set; }
        public DateTime fechaHoraCreacion { get; set; }
        public DateTime fechaHoraExpiracion { get; set; }
        public DateTime fechaHoraCambioEstado {  get; set; }
        public int ttlConfig { get; set; }
        public int failCounts { get; set; }
        public int failCountsSet {  get; set; }
    }
}
