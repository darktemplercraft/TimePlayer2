using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TaskPlayer2.Essentials.Domain.Model;
using TaskPlayer2.Essentials.Domain.Util;

namespace TaskPlayer2.Essentials.Domain.Service.TaskData
{
    public class TaskDataService
    {
        private FileHandler _fileHandler;
        public TaskDataService()
        {
            _fileHandler = new FileHandler();
        }

        /// <summary>
        /// Returns all the task from the XML file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<Tasks> GetAllTask(string fileName, bool createIfNotExist = true)
        {
            List<Tasks> tl = new List<Tasks>();

            // Read the xml file
            var doc = _fileHandler.ReadXML(fileName, createIfNotExist);
            TaskResolvers tr = new TaskResolvers();
            tl = tr.ParseTaskXmlData(doc);
            return tl;
        }



        public void SaveAllTask(List<Tasks> tl, string fileName)
        {

            // Read the xml file
            var doc = _fileHandler.ReadXML(fileName, true);
            TaskResolvers tr = new TaskResolvers();
            tl.Where(t => t.Updated == true).ToList().ForEach(t =>
            {
                tr.MappedTaskToXml(t, doc);
            });

            _fileHandler.SaveXMLFile(doc, fileName);
        }
        
    }
}
