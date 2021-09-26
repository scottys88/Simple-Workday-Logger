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
            WorkDays = WorkDayRepository.RetrieveAll();
        }

        public List<WorkDay> WorkDays { get; set; }
        public WorkDayRepository WorkDayRepository { get; private set; } = new WorkDayRepository();

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void YesOrNoButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            bool isWorkingFromHome = button.Text.ToLower() == "yes";
            Debug.WriteLine(isWorkingFromHome);

            if(!isWorkingFromHome) { 
                return; 
            }

            WorkDayRepository.CreateWorkday();
        }
    }
}
