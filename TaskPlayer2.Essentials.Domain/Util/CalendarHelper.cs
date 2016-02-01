using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlayer2.Essentials.Domain.Model;

namespace TaskPlayer2.Essentials.Domain.Util
{
    public class CalendarHelper
    {
        public List<CalendarDayDetail> GetWeekPeriodsForMonthYear(int Month, int Year)
        {
            var calendar = CultureInfo.CurrentCulture.Calendar;
           var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
           var weekPeriods =
           Enumerable.Range(1, calendar.GetDaysInMonth(Year, Month))
                     .Select(d =>
                     {
                      
                         CalendarDayDetail ct = new CalendarDayDetail();

                         var date = new DateTime(Year, Month, d);
                         ct.date = date;
                         ct.WeekOfYear = calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, firstDayOfWeek);
                         ct.DayOfTheWeek = calendar.GetDayOfWeek(date);
                         return ct;
                     })
                    // .GroupBy(x => x.WeekOfYear)
                     .ToList();

            return weekPeriods;
        }

    }
}
