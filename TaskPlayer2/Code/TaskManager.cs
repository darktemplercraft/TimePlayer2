using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlayer2.Essentials.Domain.Model;
using TaskPlayer2.Essentials.Domain.Service.TaskData;

namespace TaskPlayer2.Code
{
    public class TaskManager
    {
        public List<Tasks> MyTasks;
        TaskDataService taskDS;
        /// <summary>
        /// Init Task Manager
        /// </summary>
        public TaskManager()
        {
            MyTasks = new List<Tasks>();
            taskDS = new TaskDataService();
        }

        public Tasks CreateNewTask(string taskName)
        {
            Tasks t = new Tasks();
            t.ID = Guid.NewGuid();
            t.Name = taskName;
            t.CreatedOn = DateTime.Now;
            t.Status = (int)TasksStatus.NewTask;
            t.Updated = true;
            MyTasks.Add(t);

            // Save it right away
            SaveAllTask();

            return t;
        }

        public void TestQuery()
        {
            DateTime input = DateTime.Now;
            int Delta = DayOfWeek.Monday - input.DayOfWeek;
            DateTime monday = input.AddDays(Delta);

            var test = MyTasks.Where(t => t.Details.Any(dt => dt.StoppedOn.DayOfWeek == DayOfWeek.Monday)).ToList();
        }

        public void GetAllTask()
        {
            MyTasks = taskDS.GetAllTask(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("TaskPlayerData{0}.xml", DateTime.Today.ToString("MMMMyyyy"))));
        }

        public void SaveAllTask()
        {
            taskDS.SaveAllTask(MyTasks, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("TaskPlayerData{0}.xml", DateTime.Today.ToString("MMMMyyyy"))));
        }
    }
}
