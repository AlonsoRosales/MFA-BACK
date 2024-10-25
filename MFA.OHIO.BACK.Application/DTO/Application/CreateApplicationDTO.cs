using MFA.OHIO.BACK.Application.Common.Mappings;
using Entity = MFA.OHIO.BACK.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.DTO.Application
{
    public class CreateApplicationDTO : IMapFrom<Entity.Application>
    {
        public string nombre { get; set; }
        public char status { get; set; }
        public string ipRanges { get; set; }
    }
}
