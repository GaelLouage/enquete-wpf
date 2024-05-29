using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enquete.Helpers
{
    public static class ArrayHelper
    {
        public static void PopulateEnqueteArray(int[,] _enqueteArray,int pos, string enquete)
        {
            switch (enquete)
            {
                case "E":
                    _enqueteArray[pos, 0]++;
                    break;
                case "F":
                    _enqueteArray[pos, 1]++;
                    break;
                case "OV":
                    _enqueteArray[pos, 2]++;
                    break;
                default:
                    _enqueteArray[pos, 3]++;
                    break;
            }
        }
    }
}
