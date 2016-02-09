using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TaskPlayer2.Essentials.Domain.Model
{
    public enum TasksStatus { NewTask, StoppedTask, PlayingTask }
    public class Tasks
    {
        public string Name { get; set; }
        public Guid ID;
        public DateTime CreatedOn;
        public List<TaskDetail> Details;
        public bool Updated;
        public bool Working { get; set; }
        private TaskDetail _cacheTaskDetail;
        public double GetTotoalSecondsTimeSpent { get; set; }

        // 0 Just Added
        // 1 Stopped
        // 2 Play
        public int Status { get; set; }
        

        /// <summary>
        /// Init object
        /// </summary>
        public Tasks()
        {
            ID = Guid.Empty;
            CreatedOn = new DateTime();
            Details = new List<TaskDetail>();
            Updated = false;
            Working = false;
            
        }

        public void RefreshTimeSpent()
        {
            GetTotoalSecondsTimeSpent = Details.Sum(item => item.TimeSpentSeconds);
        }

        /// <summary>
        /// Returns the total number of hours spent on a task
        /// </summary>
        public double GetHoursSpent
        {
            get
            {
                return Math.Round(Details.Sum(item => item.TotalTimeSpentInMinutes) / 60, 2);
            }
        }

        public double GetTotalMinutesSpent
        {
            get
            {
                return Math.Round( Details.Sum(item => item.TotalTimeSpentInMinutes), 2);
            }
        }

        
       
        public string TotalFormattedTimeSpent
        {
            get
            {
                TimeSpan ts = TimeSpan.FromSeconds(GetTotoalSecondsTimeSpent);
                return string.Format("{0}:{1}.{2}", (int)ts.TotalHours, ts.Minutes, ts.Seconds);
            }
        }

        public ListViewItem GetListViewItem
        {
            get
            {
                ListViewItem taskItem = new ListViewItem(ID.ToString(), 0);
                taskItem.SubItems.Add(Name);
                taskItem.SubItems.Add(GetTotalMinutesSpent.ToString());
                taskItem.SubItems.Add(Working.ToString());
                return taskItem;
            }
        }

        public void StartTask()
        {
            _cacheTaskDetail = new TaskDetail();
            _cacheTaskDetail.ParentID = ID;
            _cacheTaskDetail.ID = Guid.NewGuid();
            _cacheTaskDetail.Updated = true;
            _cacheTaskDetail.StartedOn = DateTime.Now;
            _cacheTaskDetail.CreatedOn = DateTime.Now;
            Status = (int)TasksStatus.PlayingTask;
            Working = true;
        }

        public void PauseTask()
        {
            Status = (int)TasksStatus.StoppedTask;
            _cacheTaskDetail.StoppedOn = DateTime.Now;
            Details.Add(_cacheTaskDetail);
            Working = false;
        }


    }
}
