using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DOGPlatform.SVG
{
    class cSVGPie:cBaseMapSVG
    {

        public cSVGPie( int width,int height,int iDX, int iDY)
            : base(width, height, iDX, iDY)
        {
        
        }
        /**
 * Create an <svg> element and draw a pie chart into it.
 * Arguments:
 *   data: an array of numbers to chart, one for each wedge of the pie.
 *   width,height: the size of the SVG graphic, in pixels
 *   cx, cy, r: the center and radius of the pie
 *   colors: an array of HTML color strings, one for each wedge
 *   labels: an array of labels to appear in the legend, one for each wedge
 *   lx, ly: the upper-left corner of the chart legend
 * Returns: 
 *    An <svg> element that holds the pie chart.
 *    The caller must insert the returned element into the document.
 */
        public XmlElement gPieChart(List<float> data, int cx, int cy, float r, List<string> colors, List<string> labels, int lx, int ly) 
          {

              XmlElement gPie = svgDoc.CreateElement("g");
              // Add up the data values so we know how big the pie is

              float total = data.Sum();
              // Now figure out how big each slice of pie is. Angles in radians.
              List<double> angles = new List<double>();
              for (int i = 0; i < data.Count; i++)
                  angles.Add(data[i] / total * Math.PI * 2);

              // Loop through each slice of pie.
              double startangle = 0;
              for (int i = 0; i < data.Count; i++)
              {
                  // This is where the wedge ends
                  double endangle = startangle + angles[i];

                  // Compute the two points where our wedge intersects the circle
                  // These formulas are chosen so that an angle of 0 is at 12 o'clock
                  // and positive angles increase clockwise.
                  var x1 = cx + r * Math.Sin(startangle);
                  var y1 = cy - r * Math.Cos(startangle);
                  var x2 = cx + r * Math.Sin(endangle);
                  var y2 = cy - r * Math.Cos(endangle);

                  // This is a flag for angles larger than than a half circle
                  // It is required by the SVG arc drawing component
                  var big = 0;
                  if (endangle - startangle > Math.PI) big = 1;

                  // We describe a wedge with an <svg:path> element

                  XmlElement gPath = svgDoc.CreateElement("path");
                  // This string holds the path details
                  string d = "M " + cx + "," + cy +  // Start at circle center
                      " L " + x1 + "," + y1 +     // Draw line to (x1,y1)
                      " A " + r + "," + r +       // Draw an arc of radius r
                      " 0 " + big + " 1 " +       // Arc details...
                      x2 + "," + y2 +             // Arc goes to to (x2,y2)
                      " Z";                       // Close path back to (cx,cy)

                  // Now set attributes on the <svg:path> element
                  gPath.SetAttribute("d", d);              // Set this path 
                  gPath.SetAttribute("fill", colors[i]);   // Set wedge color
                  gPath.SetAttribute("stroke", "black");   // Outline wedge in black
                  gPath.SetAttribute("stroke-width", "1"); // 2 units thick
                  gPie.AppendChild(gPath);                // Add wedge to chart

                  // The next wedge begins where this one ends
                  startangle = endangle;

             //Now draw a little matching square for the key

                  XmlElement gIcon = svgDoc.CreateElement("rect");
                  gIcon.SetAttribute("x", lx.ToString());             // Position the square
                  gIcon.SetAttribute("y", (ly + 30 * i).ToString());
                  gIcon.SetAttribute("width", "20");         // Size the square
                  gIcon.SetAttribute("height", "20");
                  gIcon.SetAttribute("fill", colors[i]);   // Same fill color as wedge
                  gIcon.SetAttribute("stroke", "black");   // Same outline, too.
                  gIcon.SetAttribute("stroke-width", "2");
                  gPie.AppendChild(gIcon);                // Add to the chart

                  // And add a label to the right of the rectangle
                  //var label = document.createElementNS(svgns, "text");
                  XmlElement label = svgDoc.CreateElement("text");
                  label.SetAttribute("x", (lx + 30).ToString());       // Position the text
                  label.SetAttribute("y", (ly + 30 * i + 18).ToString());
                  // Text style attributes could also be set via CSS
                  label.SetAttribute("font-family", "sans-serif");
                  label.SetAttribute("font-size", "16");
                  label.InnerText = labels[i];
                  gPie.AppendChild(label);               // Add text to the chart
    }

    return gPie;
}
    }
}
