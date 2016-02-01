using Aspose.Cells;
using Microsoft.Vbe.Interop;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlayer2.Essentials.Domain.Model;
using TaskPlayer2.Properties;

namespace TaskPlayer2.Code
{
    public class ExportManager
    {
        private static readonly string asposeLicenseFile = "Aspose.Cells.lic";

        private Workbook _wb;
        private WorkbookDesigner _wbd;
        internal Settings _prop;

        public ExportManager()
        {
            License lic = new License();
            lic.SetLicense(asposeLicenseFile);

            _prop = new Settings();

            _wbd = new WorkbookDesigner();

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _prop.ReportTemplate);
            _wb = new Workbook(fileName);

        }

        public void PrepareData(TaskManager taskManager, List<CalendarDayDetail> monthCalendar)
        {
            DataSet ds = new DataSet("TaskPlayerReport");

            int i = 1;
            monthCalendar.GroupBy(x => x.WeekOfYear).ToList().ForEach(x =>
            {
                // Each Week
                var y = x;
                DataTable dt = new DataTable(string.Format("Week{0}", i));
                dt.Columns.Add("sunday", typeof(float));
                dt.Columns.Add("monday", typeof(float));
                dt.Columns.Add("tuesday", typeof(float));
                dt.Columns.Add("wednesday", typeof(float));
                dt.Columns.Add("thursday", typeof(float));
                dt.Columns.Add("friday", typeof(float));
                dt.Columns.Add("saturday", typeof(float));
                dt.Columns.Add("taskname", typeof(string));

                DataRow dr;
                taskManager.MyTasks.ForEach( tasks => {
                    dr = MappTask(dt, x, tasks);
                    if(dr != null)
                        dt.Rows.Add(dr);
                });

                ds.Tables.Add(dt);

                dt = new DataTable(string.Format("HeaderWeek{0}", i));
                dt.Columns.Add("Sunday", typeof(string));
                dt.Columns.Add("Monday", typeof(string));
                dt.Columns.Add("Tuesday", typeof(string));
                dt.Columns.Add("Wednesday", typeof(string));
                dt.Columns.Add("Thursday", typeof(string));
                dt.Columns.Add("Friday", typeof(string));
                dt.Columns.Add("Saturday", typeof(string));

                dr = dt.NewRow();
                x.ToList().ForEach(wg =>
                {
                    dr[(int)wg.DayOfTheWeek] = wg.date.ToString("MM/dd/yyyy");
                });
                dt.Rows.Add(dr);
                
                ds.Tables.Add(dt);

                i++;
            });
            

            _wbd.Workbook = _wb;
            _wbd.SetDataSource(ds);
            _wbd.Process();

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exported.xlsx");
            _wbd.Workbook.Save(filePath, SaveFormat.Xlsx);
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Open(filePath);

            
        }

        private DataRow MappTask(DataTable dt, IGrouping<int, CalendarDayDetail> weekGroup, Tasks tasks)
        {
            DataRow dr = dt.NewRow();

            if (tasks.CreatedOn >= weekGroup.First().date && tasks.CreatedOn <= weekGroup.Last().date )
            {
                weekGroup.ToList().ForEach(x =>
                {
                    dr[(int)x.DayOfTheWeek] = tasks.Details.Where(t => t.StoppedOn >= x.date).ToList().Sum( t => t.TotalTimeSpentInMinutes /60);
                });

                dr[7] = tasks.Name;

                return dr;
            }
            
            return null;            

        }

        
    }
}
