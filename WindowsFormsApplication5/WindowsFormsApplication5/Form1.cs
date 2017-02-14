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
using System.IO;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form

    {
        FileStream fstrem;
        StreamWriter strw;
        SensorDevice[] s;
        double[,] senval;
        double[] average;
        private string fileName;

        public Form1()
        {
            InitializeComponent();
            s = new SensorDevice[7] {
            new SensorDevice(18, 0, 10),
            new SensorDevice(18, 0, 10),
            new SensorDevice(18, 0, 10),
            new SensorDevice(18, 0, 10),
            new SensorDevice(18, 0, 10),
            new SensorDevice(18, 0, 10),
            new SensorDevice(18, 0, 10)
            };
            senval = new double[8, 7];
            average = new double[7];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    senval[i, j] = 0;
                    average[j] = 0.0;
                }

            }



            fileName = txtLogFile.Text;
        }

        private void helpMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\achar_mxsu8a3\OOADP\AyushA\HelpMe.txt");
        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            timer1.Interval = 3600;
            timer1.Enabled = !timer1.Enabled;
            timer1.Start();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a C# coding assignment");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string historyData = "";
            for (int j = 0; j < 7; j++)
            {
                senval[0, j] = s[j].SimulatedTemp();
                double avg = 0;
                historyData += senval[0, j].ToString() + "\t";
                for (int i = 0; i < 8; i++)
                {
                    avg += senval[i, 0];
                }
                average[j] = avg / 8;
            }
            txtHistory.AppendText("\n" + historyData);

            for (int i = 7; i > 0; i--)
            {
                for (int j = 6; j > 0; j--)
                {
                    senval[i, j] = senval[i - 1, j];
                }
            }
            txtNextSample.Text = DateTime.Now.TimeOfDay.Add(TimeSpan.FromMilliseconds(3600)).ToString();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            timer2.Interval = 33000;
            timer2.Enabled = !timer2.Enabled;
            timer2.Start();
        }

        int noOfWritings = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            txtNextLogging.Text = DateTime.Now.TimeOfDay.Add(TimeSpan.FromMilliseconds(33000)).ToString();
            fstrem = new FileStream(@"C:\Users\achar_mxsu8a3\OOADP\AyushA\" + txtLogFile.Text + ".txt", FileMode.Append);
            string cmafdata = "";
            strw = new StreamWriter(fstrem);
            for (int i = 0; i < 7; i++)
            {
                cmafdata += average[i].ToString() + "\t";
            }
            strw.Write(cmafdata + "\n");
            strw.Close();
            noOfWritings++;
            txtNoOfWritings.Text = noOfWritings.ToString();
        }

    }
}
