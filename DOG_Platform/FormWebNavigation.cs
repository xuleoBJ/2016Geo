using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using mshtml;
using DOGPlatform.SVG;

namespace DOGPlatform
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class FormWebNavigation : Form
    {
        string filepathSVG;
        public FormWebNavigation(string filepath)
        {
            InitializeComponent();
            this.filepathSVG = filepath;
            this.Text = filepath;
            webBrowserSVG.ObjectForScripting= true;
            updateWebSVG();
        }

         void updateWebSVG() 
        {
            this.tabControlSVGNavigation.Dock = DockStyle.Fill;
            if (File.Exists(filepathSVG))
            {
                this.webBrowserSVG.Navigate(new Uri(filepathSVG));
                this.tbgBaseLayerSVGView.Text = Path.GetFileNameWithoutExtension(filepathSVG);
            }
            else 
            {
                this.webBrowserSVG.Navigate("about:blank");
            }
        }

          private void openSVGfile_Click(object sender, EventArgs e)
          {
              OpenFileDialog ofdSVGPath = new OpenFileDialog();

              ofdSVGPath.Title = " 打开文件";
              ofdSVGPath.Filter = "svg文件|*.svg|所有文件|*.*";

              //设置默认文件类型显示顺序 
              ofdSVGPath.FilterIndex = 1;

              //保存对话框是否记忆上次打开的目录 
              ofdSVGPath.RestoreDirectory = true;

              if (ofdSVGPath.ShowDialog() == DialogResult.OK)
              {
                  try
                  {
                      filepathSVG = ofdSVGPath.FileName;
                      webBrowserSVG.Navigate(new Uri(filepathSVG.ToString()));
                      webBrowserSVG.ObjectForScripting = this; 
                      this.Text = filepathSVG;
                  }
                  catch (System.UriFormatException)
                  {
                      MessageBox.Show("error.");
                  }
              }
          }


          private void tabControlSVGNavigation_MouseClick(object sender, MouseEventArgs e)
          {
              MessageBox.Show("ok");
          }

          private void inkscapeToolStripMenuItem_Click(object sender, EventArgs e)
          {
              if (this.filepathSVG != "") cCallInkscape.callInk(filepathSVG);
          }

          public string Test(string args)
          {
              string[] split = args.Split();
              int x1 = int.Parse(split[0]);
              int y1 = int.Parse(split[1]);
              int x2 = int.Parse(split[2]);
              int y2 = int.Parse(split[3]);
              int x3 = int.Parse(split[4]);
              int y3 = int.Parse(split[5]);
              int x4 = int.Parse(split[6]);
              int y4 = int.Parse(split[7]);
              XElement gPath = new XElement("{http://www.w3.org/2000/svg}path");
              string dPath = "M" + x1.ToString()+" "+y1.ToString()+" L"+x2.ToString()+" "+y2.ToString()+
                  " L"+x4.ToString()+" "+y4.ToString()+" L"+x3.ToString()+" "+y3.ToString()+ "z";
              gPath.Add(new XAttribute("d", dPath));
              gPath.Add(new XAttribute("stroke", "red"));
              gPath.Add(new XAttribute("stroke-width", "1"));
              gPath.Add(new XAttribute("fill", "none"));


              XDocument XDoc = XDocument.Load(filepathSVG);
              XElement Xroot = XDoc.Root;
 
              XElement Xg = Xroot.Element("{http://www.w3.org/2000/svg}g");
              Xg.Add(gPath);

              XDoc.Save(filepathSVG);
              
              webBrowserSVG.Refresh();
              return "你输入的是：" + args;
          }

          private void tsmiMove_Click(object sender, EventArgs e)
          {
              IHTMLDocument2 htmlDocument = this.webBrowserSVG.Document.DomDocument as IHTMLDocument2;

              IHTMLSelectionObject currentSelection = htmlDocument.selection;

              //var x = webBrowserSVG.Document.GetElementById("idText123");
              
              //x.setAttributeNS(null, "x" ,200);
              //MessageBox.Show(x.Parent.Id);
              if (currentSelection != null)
              {
                  MessageBox.Show(currentSelection.type); 
                  //IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;

                  //if (range != null)
                  //{
                  //    MessageBox.Show(range.text);
                  //}
              }
          }

          private void tsmiDel_Click(object sender, EventArgs e)
          {
              
          }

          private void tsmiOilLayer_Click(object sender, EventArgs e)
          {
              XElement gPath = new XElement("{http://www.w3.org/2000/svg}path");
              string dPath = "M10 10 H 90 V 90 H 10 L 10 10 z";
              gPath.Add(new XAttribute("d", dPath));
              gPath.Add(new XAttribute("stroke", "red"));
              gPath.Add(new XAttribute("stroke-width", "1"));
              gPath.Add(new XAttribute("fill", "red"));


              XDocument XDoc = XDocument.Load(filepathSVG);
              XElement Xroot = XDoc.Root;

              XElement Xg = Xroot.Element("{http://www.w3.org/2000/svg}g");
              Xg.Add(gPath);

              XDoc.Save(filepathSVG);

              webBrowserSVG.Refresh();

          }

          private void tsmiWaterLayer_Click(object sender, EventArgs e)
          {
              XElement gPath = new XElement("{http://www.w3.org/2000/svg}path");
              string dPath = "M10 10 H 90 V 90 H 10 L 10 10 z";
              gPath.Add(new XAttribute("d", dPath));
              gPath.Add(new XAttribute("stroke", "blue"));
              gPath.Add(new XAttribute("stroke-width", "1"));
              gPath.Add(new XAttribute("fill", "blue"));


              XDocument XDoc = XDocument.Load(filepathSVG);
              XElement Xroot = XDoc.Root;

              XElement Xg = Xroot.Element("{http://www.w3.org/2000/svg}g");
              Xg.Add(gPath);

              XDoc.Save(filepathSVG);
              webBrowserSVG.Refresh();
          }


          private void tsmiHtml_Click(object sender, EventArgs e)
          {
              WriteNewDocument();
          }

          private void WriteNewDocument()
          {
              string sSVG = File.ReadAllText(filepathSVG);
              if (this.webBrowserSVG.Document != null)
              {
                  HtmlDocument doc = webBrowserSVG.Document.OpenNew(true);
                  doc.Write("<HTML> <head><script type=\"text/javascript\" src=\"d3.v2.min.js\"></script></head><BODY>"+sSVG+"</BODY></HTML>");
              }
          }

          private void tsmiD3_Click(object sender, EventArgs e)
          {
              string htmlD3 = Path.Combine(Application.StartupPath, "..", "..", "Html", "testD3.html");
              HtmlElement head = webBrowserSVG.Document.GetElementsByTagName("head")[0];
              HtmlElement scriptEl = webBrowserSVG.Document.CreateElement("script");
              IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
              element.text = "function sayHello() { alert('hello,world') }";
              head.AppendChild(scriptEl);
              webBrowserSVG.Document.InvokeScript("sayHello");
          }

          private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
          {
              WriteNewDocument();
          }

          private void tsmiEditInk_Click(object sender, EventArgs e)
          {
              if (this.filepathSVG != "") cCallInkscape.callInk(filepathSVG);
          }

          private void tsmiSystemChoose_Click(object sender, EventArgs e)
          {
              if (this.filepathSVG != "")
                  System.Diagnostics.Process.Start(this.filepathSVG);
          }

    }
}
