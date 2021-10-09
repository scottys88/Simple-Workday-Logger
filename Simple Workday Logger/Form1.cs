using ClassLibrary;
using Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Workday_Logger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetWorkdayDataBinding();
            SessionEvents = new SessionEvents();
            SystemEvents.SessionSwitch += SessionSwitchEventHandler;
        }

        public SessionEvents SessionEvents { get; set; }

        public WorkDayRepository WorkDayRepository { get; private set; } = new WorkDayRepository();
        public BindingList<WorkDay> WorkDayBindingList { get; private set; }
        public new FormWindowState WindowState { get; set; }


        private void SetWorkdayDataBinding()
        {
            List<WorkDay> workdayList = WorkDayRepository.RetrieveAll();
            WorkDayBindingList = new BindingList<WorkDay>(workdayList);
            workdayBindingSource.DataSource = WorkDayBindingList;
            dataGridView1.DataSource = workdayBindingSource;
        }

        public void HideForm()
        {            
            this.Hide();
        }

        public void ShowForm()
        {
            this.Show();
        }

        public void SessionSwitchEventHandler(object sender, SessionSwitchEventArgs e)
        {
            Debug.WriteLine(e.Reason);
            var userSessionStarted = SessionEvents.UserSessionStarted(e.Reason);
            var now = Utility.GetDate();
            var workDayDateAlreadyExists = WorkDayRepository.GetIsExistingWorkDate(now);

            if (userSessionStarted && workDayDateAlreadyExists)
            {
                HideForm();
            } else
            {
                ShowForm();
            }
        }

        public void SetUserMessage(bool isVisible, string message)
        {
            messageBox.Text = message;
            messageBox.Visible = isVisible;
        }

        private void YesOrNoButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            bool isWorkingFromHome = button.Text.ToLower() == "yes";


            if (!isWorkingFromHome)
            {
                Debug.WriteLine("Hide the form");
                this.HideForm();
                return;
            }

            try
            {
                WorkDayRepository.CreateWorkday();
                SetUserMessage(true, "New workday created");
            }
            catch (ArgumentOutOfRangeException)
            {
                SetUserMessage(true, "Existing workday with that date");
            }
        }
    }
}
