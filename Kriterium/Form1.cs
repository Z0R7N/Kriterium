using Kriterium.Properties;
using System;
using System.Drawing;
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
        bool work = false;                    // flag for click buttons start and stop
        double v1, v2;                        // volts set for devices
        string p1 = "";                       // volt string from devices
        string p2 = "";
        double dPort1, dPort2;                // double from p1 and p2
        double maxPack, minPack;              // numbers of maxium and minimum value in pack of items
        double progressR100, progressL100;    // number for progress bars
        double progressR50, progressL50;
        double dif, prcnt;                    // numbers for calculating progress bar value
        string labelValue;                    // for change data in labels value
        double variData, oldData = 0;         // value for check changing coefficient
        long oldTime, timer = 20000000;       // value for check timer and count for timer = 3 sec

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
                minVal = ConvertToDouble(args[1]);
                normVal = ConvertToDouble(args[2]);
                maxVal = ConvertToDouble(args[3]);
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
            Application.EnableVisualStyles();
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
            switchCheckBox();
            v1 = voltage1 ? 0.5 : 5;
            v2 = voltage2 ? 0.5 : 5;

            checkArguments();

            maxPack = (double)Settings.Default["maxPack"];
            minPack = (double)Settings.Default["minPack"];
            minPack = minPack == 0 ? normVal : minPack;
            tbMaxPak.Text = maxPack == 0 ? "" : maxPack.ToString();
            tbMinPak.Text = minPack == normVal ? "" : minPack.ToString();
        }


        // method for set time for timer
        private void setTimer()
        {
            oldTime = DateTime.Now.Ticks;
            this.Invoke((MethodInvoker)(() => BackColor = Color.WhiteSmoke));
        }


        // timer, if time is out returns true
        private bool checkTimer()
        {
            long t = DateTime.Now.Ticks;
            long tm = t - oldTime;
            if (tm > timer)
            {
                signalSaving();
                return true;
            }
            signalSaving(tm);
            return false;
        }


        // switch voltage check boxes
        private void switchCheckBox()
        {
            if (cbVolt1V.Checked == voltage1) cbVolt1V.Checked = !voltage1;
            if (cbVolt1M.Checked != voltage1) cbVolt1M.Checked = voltage1;
            if (cbVolt2M.Checked != voltage2) cbVolt2M.Checked = voltage2;
            if (cbVolt2V.Checked == voltage2) cbVolt2V.Checked = !voltage2;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cbPort1.Text == cbPort2.Text)
            {
                MessageBox.Show("Порты приборов должны быть разными", "Сообщение", MessageBoxButtons.OK,
        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                blockElements();
                btnStop.Focus();
                SetUpProgressBar();
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
            work = false;
            Thread.Sleep(200);
            //string exist = "check";
            //while (exist.Length != 0 && !serialPort1.IsOpen)
            //{
            //    try
            //    {
            //        exist = serialPort1.ReadExisting();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message + " port 1", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    Console.WriteLine(exist);
            //}
            //exist = "check";
            //while (exist.Length != 0 && !serialPort2.IsOpen)
            //{
            //    Thread.Sleep(100);
            //    try
            //    {
            //        exist = serialPort2.ReadExisting();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message + " port 2", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    Console.WriteLine(exist);
            //}
            closePorts();
            unBlockElements();
            BackColor = Color.WhiteSmoke;

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
            cbVolt1V.Enabled = false;
            cbVolt1M.Enabled = false;
            cbVolt2V.Enabled = false;
            cbVolt2M.Enabled = false;
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
            cbVolt1V.Enabled = true;
            cbVolt1M.Enabled = true;
            cbVolt2V.Enabled = true;
            cbVolt2M.Enabled = true;
            tbMin.Enabled = true;
            tbMax.Enabled = true;
            tbNorm.Enabled = true;
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
            labelValue = tbMin.Text;
            saveNumber(labelValue, "minValue");
            lblminVal.Text = labelValue;
            minVal = ConvertToDouble(labelValue);
        }

        private void tbNorm_TextChanged(object sender, EventArgs e)
        {
            labelValue = tbNorm.Text;
            saveNumber(labelValue, "normValue");
            lblNormVal.Text = labelValue;
            normVal = ConvertToDouble(labelValue);
        }

        private void tbMax_TextChanged(object sender, EventArgs e)
        {
            labelValue = tbMax.Text;
            saveNumber(labelValue, "maxValue");
            lblMaxVal.Text = labelValue;
            maxVal = ConvertToDouble(labelValue);
        }

        // save bool for voltage
        private void saveBool(bool data, string sett)
        {
            Settings.Default[sett] = data;
            Settings.Default.Save();
        }

        // save string to settings
        private void saveDouble(double text, string sett)
        {
            Settings.Default[sett] = text;
            Settings.Default.Save();
        }

        private void saveNumber(string data, string sett)
        {
            data = Regex.Replace(data, @"\.", ",");
            double v;
            Double.TryParse(data, out v);
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
            work = false;
            Thread.Sleep(200);
            //string exist = "check";
            //while (exist.Length != 0 && serialPort1.IsOpen)
            //{
            //    try
            //    {
            //        exist = serialPort1.ReadExisting();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    Console.WriteLine(exist);
            //}
            //exist = "check";
            //while (exist.Length != 0 && serialPort2.IsOpen)
            //{
            //    Thread.Sleep(100);
            //    try
            //    {
            //        exist = serialPort2.ReadExisting();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    Console.WriteLine(exist);
            //}
            closePorts();
        }

        private void cbVolt1_CheckedChanged(object sender, EventArgs e)
        {
            voltage1 = cbVolt1M.Checked;
            v1 = voltage1 ? 0.5 : 5;
            saveBool(voltage1, "volt1");
            switchCheckBox();
        }

        private void cbVolt1V_CheckedChanged(object sender, EventArgs e)
        {
            voltage1 = !cbVolt1V.Checked;
            v1 = voltage1 ? 0.5 : 5;
            saveBool(voltage1, "volt1");
            switchCheckBox();
        }

        private void btnClearPack_Click(object sender, EventArgs e)
        {
            minPack = normVal;
            maxPack = 0;
            saveDouble(minPack, "minPack");
            saveDouble(maxPack, "maxPack");
            tbMaxPak.Text = "";
            tbMinPak.Text = "";
            lblKoeff.Text = "0,000";
            lblPort1.Text = "0,000";
            lblPort2.Text = "0,000";
            pbLeft.Value = 0;
            pbRight.Value = 0;
            zeroProgressBar();
        }

        private void cbVolt2V_CheckedChanged(object sender, EventArgs e)
        {
            voltage2 = !cbVolt2V.Checked;
            v2 = voltage2 ? 0.5 : 5;
            saveBool(voltage2, "volt2");
            switchCheckBox();
        }

        private void cbVolt2_CheckedChanged(object sender, EventArgs e)
        {
            voltage2 = cbVolt2M.Checked;
            v2 = voltage2 ? 0.5 : 5;
            saveBool(voltage2, "volt2");
            switchCheckBox();
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
                setTimer();
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
                    dPort1 = ConvertToDouble(p1, voltage1);
                    p1 = dPort1.ToString();
                    p2 = serialPort2.ReadLine();
                    dPort2 = ConvertToDouble(p2, voltage2);
                    p2 = dPort2.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lblPort1.Invoke((MethodInvoker)(() => lblPort1.Text = p1));
                lblPort2.Invoke((MethodInvoker)(() => lblPort2.Text = p2));
                double koeffcnt = CalcCoefficient(dPort1, dPort2);
                SaveValueBatch(Math.Round(koeffcnt, 3));
                lblKoeff.Invoke((MethodInvoker)(() => lblKoeff.Text = koeffcnt.ToString("N3")));
            }
            this.Invoke((MethodInvoker)(() => BackColor = Color.WhiteSmoke));
        }

        // change string from +3.569E-1 to 0.3569
        private double ConvertToDouble(string data, bool volt = false)
        {
            double res = 0;
            //data = Regex.Replace(data, @"\.", ",");
            Double.TryParse(data, out res);
            //string divide = Regex.Replace(data, ".*E", "");
            //data = Regex.Replace(data, "[+-]", "");
            //data = Regex.Replace(data, "E.*", "");
            //res = Double.Parse(data);
            //double div = Double.Parse(divide);
            //div = Math.Pow(10, div);
            //res *= div;
            if (volt)
            {
                res *= 1000;
            }
            return res;
        }

        // calculating coefficient
        private double CalcCoefficient(double d1, double d2)
        {
            double ans = 0;
            if (d1 != 0)
            {
                ans = d2 / d1;
            }
            calculatingCoefficient(ans);
            return ans;
        }

        // settings for progress bar
        private void SetUpProgressBar()
        {
            progressL50 = normVal - minVal;
            progressL100 = progressL50 + progressL50;
            progressR50 = maxVal - normVal;
            progressR100 = progressR50 + progressR50;
        }

        // calculating coefficient of transformation
        private void calculatingCoefficient(double num)
        {
            prcnt = 0;
            bool side = true;
            if (num > normVal)
            {
                dif = num - normVal;
                if (progressR100 != 0)
                {
                    prcnt = dif * 100 / progressR100;
                }
                if (prcnt > 100) prcnt = 100;
            }
            if (num < normVal)
            {
                dif = normVal - num;
                if (progressL100 != 0)
                {
                    prcnt = dif * 100 / progressL100;
                }
                if (prcnt > 100) prcnt = 100;
                side = false;
            }
            SetProgressBar(side);
        }

        // set progress bar to 0%
        private void zeroProgressBar()
        {
            pbLeft.Invoke((MethodInvoker)(() => pbLeft.Value = 0));
            pbRight.Invoke((MethodInvoker)(() => pbRight.Value = 0));
        }

        // change progress bar | if side true - add percent for right progress bar
        private void SetProgressBar(bool side)
        {
            if (prcnt == 0)
            {
                zeroProgressBar();
            }
            else if (side)
            {
                pbRight.Invoke((MethodInvoker)(() => pbRight.Value = (int)prcnt));
                pbLeft.Invoke((MethodInvoker)(() => pbLeft.Value = 0));
            }
            else
            {
                pbLeft.Invoke((MethodInvoker)(() => pbLeft.Value = (int)prcnt));
                pbRight.Invoke((MethodInvoker)(() => pbRight.Value = 0));
            }
            if (prcnt > 50)
            {
                pbLeft.Invoke((MethodInvoker)(() => pbLeft.ForeColor = Color.OrangeRed));
                pbRight.Invoke((MethodInvoker)(() => pbRight.ForeColor = Color.OrangeRed));
            }
            else
            {
                pbLeft.Invoke((MethodInvoker)(() => pbLeft.ForeColor = Color.LimeGreen));
                pbRight.Invoke((MethodInvoker)(() => pbRight.ForeColor = Color.LimeGreen));
            }
        }



        // save value of maximum and minimum in batch
        private void SaveValueBatch(double data)
        {
            if (dPort1 > 0.005 && dPort2 > 0.005 && data >= minVal && data <= maxVal)
            {
                if (data == oldData)
                {
                    equalsCoefficient(data);
                }
                if (data > oldData)
                {
                    variData = data + data * 0.1 / 100;
                    if (variData > oldData)
                    {
                        diferentCoefficient(data);
                    }
                    else
                    {
                        equalsCoefficient(data);
                    }
                }
                if (data < oldData)
                {
                    variData = data - data * 0.1 / 100;
                    if (variData < oldData)
                    {
                        diferentCoefficient(data);
                    }
                    else
                    {
                        equalsCoefficient(data);
                    }
                }
            }
            else
            {
                this.Invoke((MethodInvoker)(() => BackColor = Color.WhiteSmoke));
            }
        }

        // if coefficient different
        private void diferentCoefficient(double data)
        {
            oldData = data;
            setTimer();
        }

        // if new cofficient same to old coefficient
        private void equalsCoefficient(double data)
        {
            if (checkTimer())
            {
                // save number no min
                if (minPack > data && data <= normVal)
                {
                    minPack = data;
                    tbMinPak.Invoke((MethodInvoker)(() => tbMinPak.Text = minPack.ToString()));
                    Settings.Default["minPack"] = minPack;
                    Settings.Default.Save();
                }
                // save number to max
                if (maxPack < data && data >= normVal)
                {
                    maxPack = data;
                    tbMaxPak.Invoke((MethodInvoker)(() => tbMaxPak.Text = maxPack.ToString()));
                    Settings.Default["maxPack"] = maxPack;
                    Settings.Default.Save();
                }
                oldData = 0;
            }
        }


        // method for signaling the storage of a number
        private void signalSaving(long tm = -1)
        {
            // change fone of application for few seconds
            if (tm < 0)
            {
                // if time is out
                this.Invoke((MethodInvoker)(() => BackColor = Color.FromArgb(255, 240, 163)));
                Thread.Sleep(150);
                this.Invoke((MethodInvoker)(() => BackColor = Color.WhiteSmoke));
            }
            else
            {
                // if time go up
                // color for green: red - 194; green - 224; blue - 196
                // color for white: red, green, blue - 245;
                // difference for interest: red - 51; green - 21; blue - 49
                double timePrcnt = tm * 100 / timer;
                timePrcnt = 100 - timePrcnt;
                double dRed = 51 * timePrcnt / 100;
                double dGreen = 21 * timePrcnt / 100;
                double dBlue = 49 * timePrcnt / 100;
                dRed += 194;
                dGreen += 224;
                dBlue += 196;
                int r = (int)dRed;
                int g = (int)dGreen;
                int b = (int)dBlue;
                this.Invoke((MethodInvoker)(() => BackColor = Color.FromArgb(r, g, b)));
            }
        }
    }
}
