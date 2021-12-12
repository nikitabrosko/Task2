using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextHandler.TextObjectModel.Texts;
using System.Xml;

namespace TextHandler.Tools
{
    public class XmlWorkingTool
    {
        public void PrintTextInXmlFile(IText text, string pathToXmlFile)
        {
            var xmlDocument = new XmlDocument();

            xmlDocument.Load(pathToXmlFile);


        }
    }
}
