﻿using Kriterium.Properties;
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
        double voltage1, voltage2;            // voltage range
        double maxVal, minVal, normVal;       // value for calculating
        double lowValue, highValue;           // value for lowest and highest value of calculating
        bool work = false;                    // flag for click buttons start and stop

        public Form1()
        {
            InitializeComponent();
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            Console.Write(cbPort1.Text + "  ");
            Console.WriteLine(cbPort2.Text);
            if (false) //(cbPort1.Text == cbPort2.Text)  < -=============================================== включить
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
                    //serialPort2.PortName = cbPort2.Text;   <----------------------------------------------------------  включить
                    serialPort1.BaudRate = 9600;
                    //serialPort2.BaudRate = 9600;
                    serialPort1.Open();
                    //serialPort2.Open();

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
            closePorts();
            Console.WriteLine("button  stop  click");
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
            tbVolt1.Enabled = false;
            tbVolt2.Enabled = false;
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
            tbVolt1.Enabled = true;
            tbVolt2.Enabled = true;
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

        private void tbVolt2_TextChanged(object sender, EventArgs e)
        {
            saveNumber(tbVolt2.Text, "volt2");
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

        private void tbVolt1_TextChanged(object sender, EventArgs e)
        {
            saveNumber(tbVolt1.Text, "volt1");
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
            closePorts();
        }

        // method manage of process
        private void setup()
        {
            try
            {
                while (!serialPort1.IsOpen)// && !serialPort2.IsOpen) < _-----------------------------------_
                {
                    Thread.Sleep(100);
                }
                //serialPort1.WriteLine("CONF:VOLT:AC " + voltage1 + Environment.NewLine);
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
                    serialPort1.WriteLine("MEAS:VOLT:AC?");
                    //serialPort2.WriteLine("MEAS:VOLT:AC?");
                }
                catch (Exception)
                {

                    // throw;
                }
                //Thread.Sleep(500);
                string p1 = "";
                string p2 = "";
                try
                {
                    p1 = serialPort1.ReadLine();
                    this.Invoke(new Action(() =>
                    {
                        tbMaxPak.Text = p1;
                    }));
                    //p2 = serialPort2.ReadLine();
                }
                catch (Exception)
                {
                    //throw;
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
                string kt = calcCoefficient(p1);//, p2);   <<============================================
                this.Invoke(new Action(() =>
                {
                    lblKoeff.Text = kt;
                }));


            }
        }

        // calculating coefficient
        private string calcCoefficient(string p1, string p2 = "0,420") // <<-----------------------------------------
        {
            string res = "ERROR";
            double num1, num2;
            p1 = Regex.Replace(p1, @"\.", ",");
            p2 = Regex.Replace(p2, @"\.", ",");
            Double.TryParse(p1, out num1);
            Double.TryParse(p2, out num2);
            double ans = num2 / num1;
            Console.WriteLine(ans);
            //res = string.Format("{0:0.####}", ans);
            res = (num2 / num1).ToString("N4");
            setProgressBar(ans);
            return res;
        }

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
            else if(num < 1)
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

        // method for timer
        //private bool timerLimit(int timer)
        //{
        //    if (millis() - *time > timer)
        //    {
        //        *time = millis();
        //        return true;
        //    }
        //    return false;
        //}
    }
}
