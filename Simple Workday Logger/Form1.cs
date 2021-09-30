using ClassLibrary;
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
        }
        
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

        public void MinimiseForm()
        {            
            this.Hide();
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
            Debug.WriteLine(isWorkingFromHome);

            if(!isWorkingFromHome) {
                //MinimiseForm();
                Debug.WriteLine("Hide the form");
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
