using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Enquete.Extensions
{
    public static class StringBuilderExtensions
    {
        public static void PopulateTextBlock(this TextBlock txt, int[,] enquteArray)
        {
            var sb = new StringBuilder();
            var year = 1960;
            sb.AppendLine($"{string.Empty.PadLeft(35)}E{string.Empty.PadLeft(10)}F{string.Empty.PadLeft(10)}OV{string.Empty.PadLeft(7)}A");
            for (int i = 0; i < enquteArray.GetLength(0); i++)
            {
                if (year < 2000)
                {
                    sb.AppendLine($"{year} < " +
                                  $"{enquteArray[i, 0].ToString().PadLeft(24)} " +
                                  $"{enquteArray[i, 1].ToString().PadLeft(10)} " +
                                  $"{enquteArray[i, 2].ToString().PadLeft(10)}" +
                                  $"{enquteArray[i, 3].ToString().PadLeft(10)}");
                    year += 10;
                }
                else
                {
                    sb.AppendLine($"{year}  - " +
                                  $"{enquteArray[i, 0].ToString().PadLeft(24)} " +
                                  $"{enquteArray[i, 1].ToString().PadLeft(10)} " +
                                  $"{enquteArray[i, 2].ToString().PadLeft(10)}" +
                                  $"{enquteArray[i, 3].ToString().PadLeft(10)}");
                }
            }
            txt.Text = sb.ToString();
        }
    }
}
