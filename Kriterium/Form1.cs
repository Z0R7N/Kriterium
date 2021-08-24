using Kriterium.Properties;
using System;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Kriterium
{
    public partial class Form1 : Form
    {
        string[] ports;
        bool voltage1, voltage2;              // voltage range - true = 0.5V,  false = 5V
        double maxVal, minVal, normVal;       // value for calculating
        double lowValue, highValue;           // value for lowest and highest value of calculating
        bool work = false;                    // flag for click buttons start and stop
        double v1, v2;                        // volts set for devices
        string p1 = "";                       // volt string from devices
        string p2 = "";
        double dPort1, dPort2;                // double from p1 and p2

        public Form1()
        {
            InitializeComponent();
        }

        // take arguments or settings
        private void checkArguments()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                minVal = convertToDouble(args[1]);
                normVal = convertToDouble(args[2]);
                maxVal = convertToDouble(args[3]);
            }
            else
            {
                maxVal = (double)Settings.Default["maxValue"];
                minVal = (double)Settings.Default["minValue"];
                normVal = (double)Settings.Default["normValue"];
            }
            tbMax.Text = maxVal.ToString();
            tbMin.Text = minVal.ToString();
            tbNorm.Text = normVal.ToString();
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

            voltage1 = (bool)Settings.Default["volt1"];
            voltage2 = (bool)Settings.Default["volt2"];
            cbVolt1.Checked = voltage1;
            cbVolt1.Text = voltage1 ? "0,5V" : "5V";
            cbVolt2.Checked = voltage2;
            cbVolt2.Text = voltage2 ? "0,5V" : "5V";
            v1 = voltage1 ? 0.5 : 5;
            v2 = voltage2 ? 0.5 : 5;

            checkArguments();
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            Console.Write(cbPort1.Text + "  ");
            Console.WriteLine(cbPort2.Text);
            if (cbPort1.Text == cbPort2.Text)
            {
                MessageBox.Show("Порты приборов должны быть разными", "Сообщение", MessageBoxButtons.OK,
        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                blockElements();
                btnStop.Focus();
                try
                {
                    serialPort1.PortName = cbPort1.Text;
                    serialPort2.PortName = cbPort2.Text;
                    serialPort1.BaudRate = 9600;
                    serialPort2.BaudRate = 9600;
                    serialPort1.Open();
                    serialPort2.Open();

                    setup();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button  stop  click");
            string exist = "check";
            while (exist.Length != 0 && !serialPort1.IsOpen)
            {
                Thread.Sleep(500);
                try
                {
                    exist = serialPort1.ReadExisting();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Console.WriteLine(exist);
            }
            exist = "check";
            while (exist.Length != 0 && !serialPort2.IsOpen)
            {
                Thread.Sleep(500);
                try
                {
                    exist = serialPort2.ReadExisting();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Console.WriteLine(exist);
            }
            closePorts();
            unBlockElements();
            lblKoeff.Text = "0,0000";
            lblPort1.Text = "0,0000";
            lblPort2.Text = "0,0000";
            pbLeft.Value = 0;
            pbRight.Value = 0;
            btnStart.Focus();
        }

        // block elements
        private void blockElements()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnChange.Enabled = false;
            cbPort1.Enabled = false;
            cbPort2.Enabled = false;
            cbVolt1.Enabled = false;
            cbVolt2.Enabled = false;
            tbMin.Enabled = false;
            tbMax.Enabled = false;
            tbNorm.Enabled = false;
            work = true;
        }

        // uhblock elements
        private void unBlockElements()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnChange.Enabled = true;
            cbPort1.Enabled = true;
            cbPort2.Enabled = true;
            cbVolt1.Enabled = true;
            cbVolt2.Enabled = true;
            tbMin.Enabled = true;
            tbMax.Enabled = true;
            tbNorm.Enabled = true;
            work = false;
        }

        //  changed combo box port 1
        private void cbPort1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string p1 = cbPort1.Text;
            Settings.Default["port1"] = p1;
            Settings.Default.Save();
        }

        private void cbPort2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string p2 = cbPort2.Text;
            Settings.Default["port2"] = p2;
            Settings.Default.Save();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            int p1 = checkList(cbPort1.Text);
            int p2 = checkList(cbPort2.Text);
            cbPort1.SelectedIndex = p2;
            cbPort2.SelectedIndex = p1;
        }

        private void tbMin_TextChanged(object sender, EventArgs e)
        {
            saveNumber(tbMin.Text, "minValue");
        }

        private void tbNorm_TextChanged(object sender, EventArgs e)
        {
            saveNumber(tbNorm.Text, "normValue");
        }

        private void tbMax_TextChanged(object sender, EventArgs e)
        {
            saveNumber(tbMax.Text, "maxValue");
        }

        // save bool for voltage
        private void saveBool(bool data, string sett)
        {
            Settings.Default[sett] = data;
            Settings.Default.Save();
        }

        private void saveNumber(string data, string sett)
        {
            data = Regex.Replace(data, @"\.", ",");
            double v;
            Double.TryParse(data, out v);
            Console.WriteLine("data = " + v);
            Settings.Default[sett] = v;
            Settings.Default.Save();
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

        // closing ports
        private void closePorts()
        {
            serialPort1.Close();
            serialPort2.Close();
        }

        // when the application is closed
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string exist = "check";
            while (exist.Length != 0 && serialPort1.IsOpen)
            {
                Thread.Sleep(500);
                try
                {
                    exist = serialPort1.ReadExisting();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Console.WriteLine(exist);
            }
            exist = "check";
            while (exist.Length != 0 && serialPort2.IsOpen)
            {
                Thread.Sleep(500);
                try
                {
                    exist = serialPort2.ReadExisting();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Console.WriteLine(exist);
            }
            closePorts();
            Thread.Sleep(100);
        }

        private void cbVolt1_CheckedChanged(object sender, EventArgs e)
        {
            voltage1 = cbVolt1.Checked;
            cbVolt1.Text = voltage1 ? "0,5V" : "5V";
            v1 = voltage1 ? 0.5 : 5;
            saveBool(voltage1, "volt1");
        }

        private void cbVolt2_CheckedChanged(object sender, EventArgs e)
        {
            voltage2 = cbVolt2.Checked;
            cbVolt2.Text = voltage2 ? "0,5V" : "5V";
            v2 = voltage2 ? 0.5 : 5;
            saveBool(voltage2, "volt2");
        }

        // method manage of process
        private void setup()
        {
            try
            {
                while (!serialPort1.IsOpen && !serialPort2.IsOpen)
                {
                    Thread.Sleep(100);
                }
                serialPort1.WriteLine("CONF:VOLT:AC " + v1);
                serialPort2.WriteLine("CONF:VOLT:AC " + v2);
                Thread lp = new Thread(loop);
                lp.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // method calculating value
        private void loop()
        {
            while (work)
            {
                //timerLimit(500);
                try
                {
                    serialPort1.WriteLine("MEAS:VOLT:AC? " + v1);
                    serialPort2.WriteLine("MEAS:VOLT:AC? " + v2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Thread.Sleep(500);

                try
                {
                    p1 = serialPort1.ReadLine();
                    dPort1 = convertToDouble(p1);
                    p1 = dPort1.ToString("N4");
                    p2 = serialPort2.ReadLine();
                    dPort2 = convertToDouble(p2);
                    p2 = dPort2.ToString("N4");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Console.WriteLine(p1);
                this.Invoke(new Action(() =>
                {
                    lblPort1.Text = p1;
                }));
                this.Invoke(new Action(() =>
                {
                    lblPort2.Text = p2;
                }));
                double koeffcnt = calcCoefficient(dPort1, dPort2);
                this.Invoke(new Action(() =>
                {
                    lblKoeff.Text = koeffcnt.ToString("N4");
                }));


            }
        }

        // change string from +3.569E-1 to 0.3569
        private double convertToDouble(string data)
        {
            double res = 0;
            data = Regex.Replace(data, @"\.", ",");
            Double.TryParse(data, out res);
            return res;
        }

        // calculating coefficient
        private double calcCoefficient(double d1, double d2)
        {
            double ans = d2 / d1;
            setProgressBar(ans);
            return ans;
        }

        // 

        // change progress bar
        private void setProgressBar(double num)
        {
            if (num > 1)
            {
                this.Invoke(new Action(() =>
                {
                    pbLeft.Value = 0;
                    pbRight.Value = 50;
                }));
            }
            else if (num < 1)
            {
                this.Invoke(new Action(() =>
                {
                    pbLeft.Value = 50;
                    pbRight.Value = 0;
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    pbLeft.Value = 0;
                    pbRight.Value = 0;
                }));
            }
        }
    }
}
