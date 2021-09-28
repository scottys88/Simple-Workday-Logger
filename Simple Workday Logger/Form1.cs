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
        }
        
        public WorkDayRepository WorkDayRepository { get; private set; } = new WorkDayRepository();
  
        private void YesOrNoButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            bool isWorkingFromHome = button.Text.ToLower() == "yes";
            Debug.WriteLine(isWorkingFromHome);

            if(!isWorkingFromHome) { 
                return; 
            }

            try
            {
                WorkDayRepository.CreateWorkday();
            }
            catch(Exception ex)
            {
                messageBox.Text = "Existing workday with that date";
                messageBox.Visible = true;
            }
        }
    }
}
