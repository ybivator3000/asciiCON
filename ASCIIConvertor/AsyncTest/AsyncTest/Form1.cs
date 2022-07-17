using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace AsyncTest
{
    public partial class Form1 : Form
    {
        static Task taskLeft = new Task(ToLeft);
        static Task taskRight = new Task(ToRight);
        public Form1()
        {
            InitializeComponent();
            myButton.ILeft += () => { taskRight.Start(); };
            myButton.IRight += () => { taskLeft.Start();};
            myButton.Start();
        }

        private void myButton_Click(object sender, EventArgs e)
        {
            
            // Method();
            if (myButton.Vector == "Right")
            {
                taskLeft.Dispose();
                Task.Delay(1);
                taskRight.Start() ;
                myButton.Start();
            }
            else if (myButton.Vector == "Left")
            {
                taskRight.Dispose();
                Task.Delay(1);
                taskLeft.Start();
                myButton.Start();
            }
        }
        static void ToRight()
        {
            Flying myButton;
            myButton = (Flying)ActiveForm.Controls.Find("myButton", false).GetValue(0);
            myButton.Vector = "Right";
                while (myButton.Location.X != 600)
                {
                    myButton.Location = new Point(myButton.Location.X + 5, myButton.Location.Y);
                    Task.Delay(1);
                }
            myButton.Start();
        }
        static void ToLeft()
        {
            ref Flying myButton = (Flying)ActiveForm.Controls.Find("myButton", false).GetValue(0);
            myButton.Text = "Ti pidoras";
            myButton.Vector = "Left";
            

            while (myButton.Location.X != 0)
            {
                myButton.Location = new Point(myButton.Location.X - 5, myButton.Location.Y);
                Task.Delay(1);
            }
            myButton.Start();
        }

    }
}