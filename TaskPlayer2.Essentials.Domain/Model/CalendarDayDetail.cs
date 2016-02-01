using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlayer2.Essentials.Domain.Model
{
    public class CalendarDayDetail
    {
        public DateTime date { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; }
        public int WeekOfYear { get; set; }

    }
}
