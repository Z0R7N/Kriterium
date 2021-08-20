using Kriterium.Properties;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Kriterium
{
    public partial class Form1 : Form
    {
        string[] ports;
        double voltage1, voltage2;            // voltage range
        double maxVal, minVal, normVal;       // value for calculating

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cbPort1.Text == cbPort2.Text)
            {
                Message.
            }
        }

        // when the app is started
        private void Form1_Load(object sender, EventArgs e)
        {
            ports = SerialPort.GetPortNames();
            cbPort1.Items.AddRange(ports);
            cbPort2.Items.AddRange(ports);
            btnStop.Enabled = false;
            int prt1 = checkList(Settings.Default["port1"].ToString());
            int prt2 = checkList(Settings.Default["port2"].ToString());
            cbPort1.SelectedIndex = prt1;
            cbPort2.SelectedIndex = prt2;

            voltage1 = (double)Settings.Default["volt1"];
            voltage2 = (double)Settings.Default["volt2"];
            tbVolt1.Text = voltage1.ToString();
            tbVolt2.Text = voltage2.ToString();

            maxVal = (double)Settings.Default["maxValue"];
            minVal = (double)Settings.Default["minValue"];
            normVal = (double)Settings.Default["normValue"];
            tbMax.Text = maxVal.ToString();
            tbMin.Text = minVal.ToString();
            tbNorm.Text = normVal.ToString();
        }

        // save info to settings
        private void saveSet()
        {

        }

        // check saved port is exist in new list
        private int checkList(string port)
        {
            int cnt = 0;
            while (cnt < ports.Length)
            {
                if (ports[cnt].Equals(port))
                {
                    return cnt;
                }
                cnt++;
            }
            return 0;
        }

        // when the application is closed
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
