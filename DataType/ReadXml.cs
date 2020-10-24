using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.IO;
namespace ConsoleApp1.DataType
{
    public class ReadXml
    {
        public void TestReadXml()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            using (FileStream fs = new FileStream("Categories.xml", FileMode.Open, FileAccess.Read))
            {
                
                foreach( XElement level1Element in XElement.Load(fs).Elements("Category"))
                {
                    Console.WriteLine($"{level1Element.Attribute("Id").Value}:{level1Element.Attribute("Name").Value}:" + 
                        $"Description:{level1Element.Attribute("Description").Value}");
                }
                
            }
        }
    }
}
