using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TaskPlayer2.Essentials.Domain.Model;
using TaskPlayer2.Essentials.Domain.Util;

namespace TaskPlayer2.Essentials.Domain.Service.TaskData
{
    public class TaskResolvers
    {
        /// <summary>
        /// Loops thru all the nodes and map it to the Task object
        /// </summary>
        /// <param name="rootTask"></param>
        /// <returns></returns>
        public List<Tasks> ParseTaskXmlData(XmlDocument doc)
        {
            XmlElement root = doc.DocumentElement;
            List<Tasks> tl = new List<Tasks>();
            var taskNodes = root.SelectNodes("Task");
            if (taskNodes.Count > 0)
            {
                foreach (XmlNode task in taskNodes)
                {
                    Tasks t = new Tasks();
                    t.ID = StringHelper.ParseGuid(task.Attributes["id"].Value);
                    t.Name = task.Attributes["name"].Value;
                    t.CreatedOn = StringHelper.ParseDateTime(task.Attributes["createdon"].Value);
                    t.Status = StringHelper.ParseInt(task.Attributes["status"].Value);

                    var taskDetails = task.SelectNodes("TaskDetail");
                    foreach (XmlNode taskDetail in taskDetails)
                    {
                        TaskDetail td = new TaskDetail();
                        td.ID = StringHelper.ParseGuid(taskDetail.Attributes["id"].Value);
                        td.ParentID = StringHelper.ParseGuid(taskDetail.Attributes["parentid"].Value);
                        td.CreatedOn = StringHelper.ParseDateTime(taskDetail.Attributes["createdon"].Value);
                        td.StartedOn = StringHelper.ParseDateTime(taskDetail.Attributes["start"].Value);
                        td.StoppedOn = StringHelper.ParseDateTime(taskDetail.Attributes["stop"].Value);
                        td.TimeSpentSeconds = StringHelper.ParseDouble(taskDetail.Attributes["timespent"].Value);
                        t.Details.Add(td);
                    }
                    t.RefreshTimeSpent();
                    tl.Add(t);
                }
            }

            return tl;
        }

        /// <summary>
        /// Mapped the Task node
        /// </summary>
        /// <param name="t"></param>
        /// <param name="doc"></param>
        public void MappedTaskToXml(Tasks t, XmlDocument doc)
        {
            var node = doc.SelectSingleNode(string.Format("Tasks/Task[@id='{0}']", t.ID));
            if ( node != null)
            {
                node.Attributes["name"].Value = t.Name;
                node.Attributes["status"].Value = t.Status.ToString();
                MappedTaskDetailToXml(t.Details, doc, (XmlElement)node);
            }
            else
            {
                XmlElement element = doc.CreateElement("Task");
                SetElementAttribute(doc, "id", t.ID.ToString(), element);
                SetElementAttribute(doc, "name", t.Name, element);
                SetElementAttribute(doc, "createdon", t.CreatedOn.ToString(), element);
                SetElementAttribute(doc, "status", t.Status.ToString(), element);

                MappedTaskDetailToXml(t.Details, doc, element);
                
                doc.SelectSingleNode("Tasks").AppendChild(element);
            }

            // Make sure to reset the flag
            t.Updated = false;
        }

        public void ConverTaskDetailsToTable(List<Tasks> tasks)
        {
            DataTable table = new DataTable();

            // Init columns
            table.Columns.Add("TaskId", typeof(Guid));
            table.Columns.Add("TaskName", typeof(string));
            table.Columns.Add("TaskDetailId", typeof(Guid));
            table.Columns.Add("stop", typeof(DateTime));
            table.Columns.Add("timehourspent", typeof(double));


        }


        /// <summary>
        /// Mapped the Task Details Node
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="doc"></param>
        /// <param name="element"></param>
        public void MappedTaskDetailToXml(List<TaskDetail> dt, XmlDocument doc, XmlElement element)
        {
            dt.Where(td => td.Updated == true).ToList().ForEach(td =>
            {
                var node = element.SelectSingleNode(string.Format("TaskDetail[@id='{0}']", td.ID));
                if (node != null)
                {
                    node.Attributes["start"].Value = td.StartedOn.ToString();
                    node.Attributes["stop"].Value = td.StoppedOn.ToString();
                    // Just in case user override the time spent during editing
                    node.Attributes["timespent"].Value = td.TimeSpentSeconds.ToString();
                }
                else
                {
                    XmlElement detailElement = doc.CreateElement("TaskDetail");
                    SetElementAttribute(doc, "parentid", td.ParentID.ToString(), detailElement);
                    SetElementAttribute(doc, "id", td.ID.ToString(), detailElement);
                    SetElementAttribute(doc, "createdon", td.CreatedOn.ToString(), detailElement);
                    SetElementAttribute(doc, "start", td.StartedOn.ToString(), detailElement);
                    SetElementAttribute(doc, "stop", td.StoppedOn.ToString(), detailElement);
                    // Save Time spent for the first time
                    SetElementAttribute(doc, "timespent", td.TotalTimeSpentInSeconds.ToString(), detailElement);
                    // add to task
                    element.AppendChild(detailElement);
                }

                // Make sure to reset the flag
                td.Updated = false;
            });
        }

        private void SetElementAttribute(XmlDocument doc, string attributeName, string value, XmlElement el)
        {
            XmlAttribute attr = doc.CreateAttribute(attributeName);
            attr.Value = value;
            el.Attributes.Append(attr);
        }

    }
}