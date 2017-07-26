using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace PSC.Xam.Controls.BindableCheckboxList.UWP.Extensions
{
    /// <summary>
    /// Class ColorExtensions.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts the type of the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Color.</returns>
        public static Color ConvertColorType(this Xamarin.Forms.Color color)
        {
            double AVal = color.A * 255;
            double RVal = color.R * 255;
            double GVal = color.G * 255;
            double BVal = color.B * 255;

            return Color.FromArgb((byte)AVal, (byte)RVal, (byte)GVal, (byte)BVal);
        }
    }
}
