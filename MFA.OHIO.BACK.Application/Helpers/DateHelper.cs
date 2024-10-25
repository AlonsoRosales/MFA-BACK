using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MFA.OHIO.BACK.Application.Helpers
{
    public sealed class DateHelper
    {
        private readonly string _dateFormat = "yyyy/MM";
        public bool validateDate(string date)
        {            
            try
            {
                DateTime parsedDate = DateTime.ParseExact(date, _dateFormat, CultureInfo.InvariantCulture);
                return (parsedDate.Month < 1 || parsedDate.Year > 12) ? false : true;    
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool validateServerTime(string date)
        {
            try
            {
                DateTime parsedDate = DateTime.ParseExact(date, _dateFormat, CultureInfo.InvariantCulture);
                DateTime currentDate = DateTime.Now;
                return parsedDate.Year == currentDate.Year && parsedDate.Month == currentDate.Month;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
