using MFA.OHIO.BACK.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using Entity = MFA.OHIO.BACK.Core.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.DTO.Application
{
    public class GetAllApplicationsDTO : IMapFrom<Entity.Application>
    {
        public int applicationId { get; set; }
        public string nombre { get; set; }
        public char status { get; set; }
        public DateTime fechaHoraCreacion { get; set; }
        public string ipRanges { get; set; }
    }
}
