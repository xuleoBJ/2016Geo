using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DigRobot
{
        class colorOper
        {
            public static string getRGB(Color m_color)
            {
                string r = m_color.R.ToString();
                string g = m_color.G.ToString();
                string b = m_color.B.ToString();
                return "rgb(" + r + "," + g + "," + b + ")";
            }

            public static String HexConverter(System.Drawing.Color c)
            {
                return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            }

            public static String HexConverter(int r, int g, int b)
            {
                return "#" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
            }

            public static String RGBConverter(System.Drawing.Color c)
            {
                return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
            }
        }
}
