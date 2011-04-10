using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTest.core.maps;
using System.Drawing;

namespace MTest.view
{
    class DrawMapHelper
    {
        public static Color getColor(int i)
        {
            if (i == Map.UNKNOWN_MAP_STATE)
            {
                return getUnknownColor();
            }
            else
            {
                int rgb = (int)Math.Ceiling(255 * ((double)i / (double)int.MaxValue));
                return Color.FromArgb(rgb, rgb, rgb);
            }
        }

        public static Color getUnknownColor()
        {
           return Color.Plum;
        }
    }
}
