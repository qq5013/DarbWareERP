using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace 邏輯
{
    public class XmlToSql<T>
    {
        /// <summary>
        /// 將LIST轉成插入SQL的XML格式
        /// </summary>
        /// <param name="data">輸入要插入SQL的表</param>
        public static string WriteXml(List<T> data)
        {
            string 資料夾路徑 = @"c:/TEMPS/XML/";
            Type t = typeof(T);
            XmlSerializer serialiser = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("VFPData"));
            if (!Directory.Exists(資料夾路徑))
            {
                Directory.CreateDirectory(資料夾路徑);
            }
            TextWriter Filestream = new StreamWriter(資料夾路徑 + t.Name + ".xml");
            //增加空的命名空間，以符合sql預存程序的格式                    
            XmlSerializerNamespaces xn = new XmlSerializerNamespaces();
            xn.Add("", "");
            serialiser.Serialize(Filestream, data, xn);            
            Filestream.Close();
            Filestream.Dispose();
            XDocument xd = XDocument.Load(資料夾路徑 + t.Name + ".xml");
            foreach (XElement xe in xd.Root.Elements(t.Name))
            {
                xe.Name = "tmpdata";
            }
            //xd.Root.Element(t.Name).Name = "tmpdata";
            xd.Save(資料夾路徑 + t.Name + ".xml");
            return xd.Document.ToString();
        }
    }
}
