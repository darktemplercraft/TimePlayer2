using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskPlayer2.Code;
using TaskPlayer2.Essentials.Domain.Model;
using TaskPlayer2.Essentials.Domain.Util;

namespace TaskPlayer2
{
    public partial class frmMain : Form
    {
        private TaskManager _TaskManager;
        private Tasks _currentSelectedTask;


        public frmMain()
        {
            InitializeComponent();
            _TaskManager = new TaskManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            _TaskManager.GetAllTask();
            _TaskManager.MyTasks.ForEach(t => olvTaskGrid.AddObject(t));

            //ucTimePlayer.Populate(tm.MyTasks);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_currentSelectedTask != null)
                StopCounter();

            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddNewTask();
        }


        private void AddNewTask()
        {
            if (!string.IsNullOrEmpty(txbAddTask.Text))
            {
                // Build new Task
                olvTaskGrid.AddObject(_TaskManager.CreateNewTask(txbAddTask.Text));
                txbAddTask.Text = string.Empty;
            }
        }

        private void txbAddTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AddNewTask();
            }

        }

        private void tCounterPulse_Tick(object sender, EventArgs e)
        {
            _currentSelectedTask.Updated = true;
            _currentSelectedTask.GetTotoalSecondsTimeSpent++;
            olvTaskGrid.RefreshObject(_currentSelectedTask);
        }

        private void btnPlayStop_Click(object sender, EventArgs e)
        {
            if (olvTaskGrid.SelectedItems.Count > 0)
            {
                var selectedTask = (Tasks)olvTaskGrid.SelectedObject;


                if (_currentSelectedTask == null)
                {
                    _currentSelectedTask = selectedTask;
                    StartCounter();
                }
                else
                {

                    // Check the Current Status
                    switch (_currentSelectedTask.Status)
                    {
                        case (int)TasksStatus.NewTask:
                            StartCounter();
                            break;
                        case (int)TasksStatus.PlayingTask:
                            StopCounter();
                            break;
                        case (int)TasksStatus.StoppedTask:
                            StartCounter();
                            break;
                    }

                    // Switch to new Task if selected is not same as currently playing
                    if (selectedTask.ID != _currentSelectedTask.ID)
                    {
                        _currentSelectedTask = selectedTask;
                        StartCounter();
                    }


                }

            }

        }

        private void StartCounter()
        {
            _currentSelectedTask.StartTask();
            tCounterPulse.Enabled = true;
            ToggleButtonImage();
        }

        private void StopCounter()
        {
            tCounterPulse.Enabled = false;
            _currentSelectedTask.PauseTask();
            olvTaskGrid.RefreshObject(_currentSelectedTask);

            var index = _TaskManager.MyTasks.FindIndex(t => t.ID == _currentSelectedTask.ID);
            _TaskManager.MyTasks[index] = _currentSelectedTask;

            // Save the details
            _TaskManager.SaveAllTask();
            ToggleButtonImage();

        }

        private void olvTaskGrid_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            ToggleButtonImage();

        }

        private void ToggleButtonImage(object sender, EventArgs e)
        {
            ToggleButtonImage();
        }

        private void ToggleButtonImage()
        {
            if (olvTaskGrid.SelectedItems.Count > 0)
            {
                var selectedTask = (Tasks)olvTaskGrid.SelectedObject;
                switch (selectedTask.Status)
                {
                    case (int)TasksStatus.NewTask:
                    case (int)TasksStatus.StoppedTask:
                        btnPlayStop.Image = Properties.Resources.start;
                        break;
                    default:
                        btnPlayStop.Image = Properties.Resources.stop;
                        break;
                }
            }

        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_TaskManager.TestQuery();

            ExportManager em = new ExportManager();
            CalendarHelper ch = new CalendarHelper();

            em.PrepareData(_TaskManager.MyTasks, ch.GetWeekPeriodsForMonthYear(DateTime.Today.Month, DateTime.Today.Year), "Exported.xlsx");


        }
    }
}
