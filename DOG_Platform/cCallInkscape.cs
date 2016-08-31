using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DOGPlatform
{
    class cCallInkscape
    {
        public static void callInk(string svgfilepath)
        {
            if (!File.Exists(cProjectManager.filePathInkscape))
            {
                if (findPathInkscape() == false) cProjectManager.filePathInkscape = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Inkscape", "Inkscape.exe");
            }
            if (svgfilepath != "" && File.Exists(cProjectManager.filePathInkscape)) 
                System.Diagnostics.Process.Start(cProjectManager.filePathInkscape, svgfilepath); 
            
        }

        public static bool findPathInkscape()
        {
            List<string> ListSearchPath = new List<string>();
            ListSearchPath.Add(@"C:\Program Files\Inkscape");
            ListSearchPath.Add(@"C:\Program Files (x86)\Inkscape");
            ListSearchPath.Add(@"D:\Program Files\Inkscape");
            ListSearchPath.Add(@"D:\Program Files (x86)\Inkscape");
            foreach (string sPath in ListSearchPath) 
            {
                string filePath=Path.Combine(sPath,"inkscape.exe");
                if (File.Exists(filePath)) 
                {
                    cProjectManager.filePathInkscape = filePath;
                    cProjectManager.dirPahtInkExtension = Path.Combine(Path.GetDirectoryName(cProjectManager.filePathInkscape), "share", "extensions"); 
                    cProjectManager.filePahtsvgPattern = Path.Combine(Path.GetDirectoryName(cProjectManager.filePathInkscape), "share", "patterns", "patterns.svg");
                    cIOBase.GrantAccess(Path.GetDirectoryName(cProjectManager.filePahtsvgPattern));
                   // File.SetAccessControl(cProjectManager.filePahtsvgPattern, fileSecur);
                    return true ;
                }
            }
            return false;
        }
    }
}
