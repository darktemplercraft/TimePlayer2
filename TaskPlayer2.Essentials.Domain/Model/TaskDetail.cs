using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlayer2.Essentials.Domain.Model
{
    public class TaskDetail
    {
        public Guid ParentID;
        public Guid ID;
        public DateTime CreatedOn;
        public DateTime StartedOn;
        public DateTime StoppedOn;
        public bool Updated;
        public double TimeSpentSeconds { get; set; }

        public TaskDetail()
        {
            CreatedOn = new DateTime();
            StartedOn = new DateTime();
            StoppedOn = new DateTime();
            Updated = false;
        }

        public double TotalTimeSpentInMinutes
        {

            get
            {
                TimeSpan ts = TimeSpan.FromSeconds(TimeSpentSeconds);
                return Math.Round(ts.TotalMinutes,2);
            }
        }


        public double TotalTimeSpentInSeconds
        {
            get
            {
                return StoppedOn.Subtract(CreatedOn).TotalSeconds;
            }
        }
    }
}
