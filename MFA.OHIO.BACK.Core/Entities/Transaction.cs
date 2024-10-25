using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Core.Entity
{
    public class Transaction
    {
        public int transactionId {  get; set; }
        public int messageType { get; set; }
        public int originType {  get; set; }
        public int grantedUserId {  get; set; }
        public int applicationId { get; set; }
        public string ipv4 {  get; set; }
        public DateTime reqDate { get; set; }
        public string tokenGenerated { get; set; }
        public string tokenRequested {  get; set; }
        public DateTime fechaHoraTransaccion {  get; set; }
        public string responseStatus {  get; set; }
        public string responseMessage {  get; set; }
        public string detalleAdicional { get; set; }
    }
}
