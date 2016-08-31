using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOGPlatform
{
    class ItemConnectInjPro
    {
          public string sYM;
          public string sXCM;
          public string sJHinj;
          public string sJHpro;
          public float factorSplit;

          public static string item2string(ItemConnectInjPro item)
          {
              List<string> ltStrWrited = new List<string>();
              ltStrWrited.Add(item.sYM);
              ltStrWrited.Add(item.sXCM);
              ltStrWrited.Add(item.sJHinj);
              ltStrWrited.Add(item.sJHpro);
              ltStrWrited.Add(item.factorSplit.ToString());
              return string.Join("\t", ltStrWrited.ToArray());
          }

          public static ItemConnectInjPro parseLine(string line)
          {
              string[] split = line.Trim().Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
              ItemConnectInjPro item = new ItemConnectInjPro();
              if (split.Length >= 4)
              {
                  item.sYM= split[0];
                  item.sXCM = split[1];
                  item.sJHinj= split[2];
                  item.sJHpro =split[3] ;
                  item.factorSplit = 0.0f;
                  float.TryParse(split[4], out item.factorSplit);
              }
              return item;
          } 
        
    }
}
