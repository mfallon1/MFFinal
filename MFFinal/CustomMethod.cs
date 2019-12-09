using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFFinal
{
    class CustomMethod  // error handler
    {

        public static bool IsBlank(string s)
        {
            if (s == " " || s == "" || s == null)
            {
                return true;
            }
            return false;
        }

        public static bool IsDec(string s)
        {
            decimal decprice;
            if (Decimal.TryParse(s, out decprice))
            {
                return true;
            }
            else
                return false;
        }


        public static bool IsInt(string s)
        {
            Int16 intunits;

            if (Int16.TryParse(s, out intunits))
            {
                return true;
            }
            else
                return false;
        }
    }
}
