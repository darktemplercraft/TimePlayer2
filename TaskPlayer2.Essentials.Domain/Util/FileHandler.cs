using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TaskPlayer2.Essentials.Domain.Util
{
    public class FileHandler
    {
       
        /// <summary>
        /// Init class
        /// </summary>
        public FileHandler()
        {
            
        }


        public bool FileExist(String fileName)
        {
            return File.Exists(fileName);
        }

        /// <summary>
        /// File Getter
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string ReadFile(string filename)
        {
          
            return "";
        }


        public XmlDocument ReadXML(string filename, bool createIfNotExist)
        {
            XmlDocument doc = new XmlDocument();

            if (FileExist(filename))
            {
                doc.Load(filename);
            }else if (createIfNotExist)
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement tasksEl = doc.CreateElement("Tasks");
                doc.AppendChild(tasksEl);

                doc.Save(filename);
            }
            
            return doc;
        }

        public void SaveXMLFile(XmlDocument doc, string fileName)
        {
            doc.Save(fileName);
        }

        public void RenameFile(string oldFileName, string newFileName)
        {
            File.Move(oldFileName, newFileName);
        }
    }
}
