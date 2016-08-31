using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DOGPlatform
{
    class cSVG2Html
    {
        public static string svg2htmlByContent(string filePathSVG) 
        {
            string filePathHtml=filePathSVG.Replace(".svg",".html");
            string fileName = "base.html";

            //Read HTML from file
            var content = File.ReadAllText(fileName);

            var svgBody = File.ReadAllText(filePathSVG, Encoding.UTF8);
            //Replace all values in the HTML
            content = content.Replace("{svg_content}", svgBody);

            //Write new HTML string to file
            File.WriteAllText(filePathHtml, content, Encoding.UTF8);
            return filePathHtml;
        }


        public static string svg2htmlByObject(string filePathSVG)
        {
            string filePathHtml = filePathSVG.Replace(".svg", ".html");
            string fileName = "html//baseObject.html";

            //Read HTML from file
            var content = File.ReadAllText(fileName);

            //Replace all values in the HTML
            content = content.Replace("{svg_path}", filePathSVG);

            //Write new HTML string to file
            File.WriteAllText(filePathHtml, content, Encoding.UTF8);
            return filePathHtml;
        }

        public static string svg2htmlByEmbed(string filePathSVG)
        {
            string filePathHtml = filePathSVG.Replace(".svg", ".html");
             string fileName = "baseScript.html";

            //Read HTML from file
            var content = File.ReadAllText(fileName);

            //Replace all values in the HTML
            content = content.Replace("{svg_path}", filePathSVG);

            //Write new HTML string to file
            File.WriteAllText(filePathHtml, content, Encoding.UTF8);
            return filePathHtml;
        }
    }
}
