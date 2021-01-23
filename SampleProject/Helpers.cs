using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject
{
    class Helpers
    {
		public static string Numeric2Bytes(double b)
		{
			string tempNumeric2Bytes = null;
			string[] bSize = new string[9];
			int i = 0;

			bSize[0] = "Bytes";
			bSize[1] = "KB"; //Kilobytes
			bSize[2] = "MB"; //Megabytes
			bSize[3] = "GB"; //Gigabytes
			bSize[4] = "TB"; //Terabytes
			bSize[5] = "PB"; //Petabytes
			bSize[6] = "EB"; //Exabytes
			bSize[7] = "ZB"; //Zettabytes
			bSize[8] = "YB"; //Yottabytes

			b = (double)b; // Make sure var is a Double (not just
						   // variant)
			for (i = bSize.GetUpperBound(0); i >= 0; i--)
			{
				if (b >= (Math.Pow(1024, i)))
				{
					tempNumeric2Bytes = ThreeNonZeroDigits(b / (Math.Pow(1024, i))) + " " + bSize[i];
					break;
				}
			}
			return tempNumeric2Bytes;
		}
		private static string ThreeNonZeroDigits(double value)
		{
			if (value >= 100)
			{
				// No digits after the decimal.
				return Microsoft.VisualBasic.Strings.Format(Convert.ToInt32(value));
			}
			else if (value >= 10)
			{
				// One digit after the decimal.
				return value.ToString("0.0");
			}
			else
			{
				return value.ToString("0.00");
			}
		}

	}
}
