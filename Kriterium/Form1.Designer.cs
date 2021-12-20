
namespace Kriterium
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.cbPort1 = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbPort2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNorm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pbRight = new System.Windows.Forms.ProgressBar();
            this.pbLeft = new System.Windows.Forms.ProgressBar();
            this.lblPort1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblKoeff = new System.Windows.Forms.Label();
            this.lblPort2 = new System.Windows.Forms.Label();
            this.tbMinPak = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbMaxPak = new System.Windows.Forms.TextBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.btnChange = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbVolt1M = new System.Windows.Forms.CheckBox();
            this.cbVolt2M = new System.Windows.Forms.CheckBox();
            this.cbVolt1V = new System.Windows.Forms.CheckBox();
            this.cbVolt2V = new System.Windows.Forms.CheckBox();
            this.btnClearPack = new System.Windows.Forms.Button();
            this.lblNormVal = new System.Windows.Forms.Label();
            this.lblminVal = new System.Windows.Forms.Label();
            this.lblMaxVal = new System.Windows.Forms.Label();
            this.btnSaveVal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPort1
            // 
            this.cbPort1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPort1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPort1.FormattingEnabled = true;
            this.cbPort1.Location = new System.Drawing.Point(155, 52);
            this.cbPort1.Name = "cbPort1";
            this.cbPort1.Size = new System.Drawing.Size(155, 33);
            this.cbPort1.TabIndex = 8;
            this.cbPort1.SelectedIndexChanged += new System.EventHandler(this.cbPort1_SelectedIndexChanged);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStop.BackColor = System.Drawing.Color.MistyRose;
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStop.Location = new System.Drawing.Point(795, 41);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(115, 53);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(42, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Прибор 1:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(674, 41);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(115, 53);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Пуск";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbPort2
            // 
            this.cbPort2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPort2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPort2.FormattingEnabled = true;
            this.cbPort2.Location = new System.Drawing.Point(500, 52);
            this.cbPort2.Name = "cbPort2";
            this.cbPort2.Size = new System.Drawing.Size(154, 33);
            this.cbPort2.TabIndex = 9;
            this.cbPort2.SelectedIndexChanged += new System.EventHandler(this.cbPort2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(383, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Прибор 2:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(42, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "минимальное";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(42, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Диапазон напряжения: прибор 1";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(566, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "прибор 2";
            // 
            // tbMin
            // 
            this.tbMin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMin.Location = new System.Drawing.Point(197, 250);
            this.tbMin.Name = "tbMin";
            this.tbMin.Size = new System.Drawing.Size(124, 31);
            this.tbMin.TabIndex = 17;
            this.tbMin.TextChanged += new System.EventHandler(this.tbMin_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(358, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "номинал";
            // 
            // tbNorm
            // 
            this.tbNorm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNorm.Location = new System.Drawing.Point(463, 250);
            this.tbNorm.Name = "tbNorm";
            this.tbNorm.Size = new System.Drawing.Size(127, 31);
            this.tbNorm.TabIndex = 19;
            this.tbNorm.TextChanged += new System.EventHandler(this.tbNorm_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(608, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "максимальное";
            // 
            // tbMax
            // 
            this.tbMax.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMax.Location = new System.Drawing.Point(773, 250);
            this.tbMax.Name = "tbMax";
            this.tbMax.Size = new System.Drawing.Size(137, 31);
            this.tbMax.TabIndex = 21;
            this.tbMax.TextChanged += new System.EventHandler(this.tbMax_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(42, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(533, 25);
            this.label8.TabIndex = 22;
            this.label8.Text = "Значения замеров:   (прибор 2 делить на  прибор 1)";
            // 
            // pbRight
            // 
            this.pbRight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbRight.Location = new System.Drawing.Point(491, 298);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(397, 23);
            this.pbRight.Step = 1;
            this.pbRight.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbRight.TabIndex = 23;
            // 
            // pbLeft
            // 
            this.pbLeft.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbLeft.Location = new System.Drawing.Point(97, 298);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pbLeft.RightToLeftLayout = true;
            this.pbLeft.Size = new System.Drawing.Size(397, 23);
            this.pbLeft.Step = 1;
            this.pbLeft.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbLeft.TabIndex = 24;
            // 
            // lblPort1
            // 
            this.lblPort1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPort1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPort1.Location = new System.Drawing.Point(47, 448);
            this.lblPort1.Name = "lblPort1";
            this.lblPort1.Size = new System.Drawing.Size(263, 55);
            this.lblPort1.TabIndex = 28;
            this.lblPort1.Text = "0,000";
            this.lblPort1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(130, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 25);
            this.label10.TabIndex = 29;
            this.label10.Text = "прибор 1";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(749, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 25);
            this.label11.TabIndex = 30;
            this.label11.Text = "прибор 2";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(425, 410);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 25);
            this.label12.TabIndex = 31;
            this.label12.Text = "коэффициент";
            // 
            // lblKoeff
            // 
            this.lblKoeff.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblKoeff.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblKoeff.Location = new System.Drawing.Point(342, 435);
            this.lblKoeff.Name = "lblKoeff";
            this.lblKoeff.Size = new System.Drawing.Size(326, 91);
            this.lblKoeff.TabIndex = 32;
            this.lblKoeff.Text = "0,000";
            this.lblKoeff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPort2
            // 
            this.lblPort2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPort2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPort2.Location = new System.Drawing.Point(691, 448);
            this.lblPort2.Name = "lblPort2";
            this.lblPort2.Size = new System.Drawing.Size(219, 55);
            this.lblPort2.TabIndex = 33;
            this.lblPort2.Text = "0,000";
            this.lblPort2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbMinPak
            // 
            this.tbMinPak.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMinPak.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMinPak.Location = new System.Drawing.Point(119, 591);
            this.tbMinPak.Name = "tbMinPak";
            this.tbMinPak.ReadOnly = true;
            this.tbMinPak.Size = new System.Drawing.Size(263, 40);
            this.tbMinPak.TabIndex = 34;
            this.tbMinPak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(87, 552);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(342, 25);
            this.label15.TabIndex = 37;
            this.label15.Text = "минимальное значение в партии";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(531, 552);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(352, 25);
            this.label16.TabIndex = 38;
            this.label16.Text = "максимальное значение в партии";
            // 
            // tbMaxPak
            // 
            this.tbMaxPak.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMaxPak.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMaxPak.Location = new System.Drawing.Point(571, 591);
            this.tbMaxPak.Name = "tbMaxPak";
            this.tbMaxPak.ReadOnly = true;
            this.tbMaxPak.Size = new System.Drawing.Size(263, 40);
            this.tbMaxPak.TabIndex = 41;
            this.tbMaxPak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnChange
            // 
            this.btnChange.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChange.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnChange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChange.BackgroundImage")));
            this.btnChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChange.Location = new System.Drawing.Point(328, 52);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(49, 33);
            this.btnChange.TabIndex = 42;
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.ErrorImage")));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.InitialImage")));
            this.pictureBox3.Location = new System.Drawing.Point(668, 323);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 27;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.ErrorImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(470, 323);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(273, 323);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // cbVolt1M
            // 
            this.cbVolt1M.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbVolt1M.AutoSize = true;
            this.cbVolt1M.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVolt1M.Location = new System.Drawing.Point(388, 117);
            this.cbVolt1M.Name = "cbVolt1M";
            this.cbVolt1M.Size = new System.Drawing.Size(81, 29);
            this.cbVolt1M.TabIndex = 43;
            this.cbVolt1M.Text = "0,5 V";
            this.cbVolt1M.UseVisualStyleBackColor = true;
            this.cbVolt1M.CheckedChanged += new System.EventHandler(this.cbVolt1_CheckedChanged);
            // 
            // cbVolt2M
            // 
            this.cbVolt2M.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbVolt2M.AutoSize = true;
            this.cbVolt2M.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVolt2M.Location = new System.Drawing.Point(674, 117);
            this.cbVolt2M.Name = "cbVolt2M";
            this.cbVolt2M.Size = new System.Drawing.Size(81, 29);
            this.cbVolt2M.TabIndex = 44;
            this.cbVolt2M.Text = "0,5 V";
            this.cbVolt2M.UseVisualStyleBackColor = true;
            this.cbVolt2M.CheckedChanged += new System.EventHandler(this.cbVolt2_CheckedChanged);
            // 
            // cbVolt1V
            // 
            this.cbVolt1V.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbVolt1V.AutoSize = true;
            this.cbVolt1V.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVolt1V.Location = new System.Drawing.Point(388, 152);
            this.cbVolt1V.Name = "cbVolt1V";
            this.cbVolt1V.Size = new System.Drawing.Size(75, 29);
            this.cbVolt1V.TabIndex = 45;
            this.cbVolt1V.Text = "  5 V";
            this.cbVolt1V.UseVisualStyleBackColor = true;
            this.cbVolt1V.CheckedChanged += new System.EventHandler(this.cbVolt1V_CheckedChanged);
            // 
            // cbVolt2V
            // 
            this.cbVolt2V.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbVolt2V.AutoSize = true;
            this.cbVolt2V.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbVolt2V.Location = new System.Drawing.Point(674, 152);
            this.cbVolt2V.Name = "cbVolt2V";
            this.cbVolt2V.Size = new System.Drawing.Size(75, 29);
            this.cbVolt2V.TabIndex = 46;
            this.cbVolt2V.Text = "  5 V";
            this.cbVolt2V.UseVisualStyleBackColor = true;
            this.cbVolt2V.CheckedChanged += new System.EventHandler(this.cbVolt2V_CheckedChanged);
            // 
            // btnClearPack
            // 
            this.btnClearPack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClearPack.BackColor = System.Drawing.Color.PeachPuff;
            this.btnClearPack.Location = new System.Drawing.Point(429, 586);
            this.btnClearPack.Name = "btnClearPack";
            this.btnClearPack.Size = new System.Drawing.Size(100, 51);
            this.btnClearPack.TabIndex = 47;
            this.btnClearPack.Text = "Стереть";
            this.btnClearPack.UseVisualStyleBackColor = false;
            this.btnClearPack.Click += new System.EventHandler(this.btnClearPack_Click);
            // 
            // lblNormVal
            // 
            this.lblNormVal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNormVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNormVal.Location = new System.Drawing.Point(446, 360);
            this.lblNormVal.Name = "lblNormVal";
            this.lblNormVal.Size = new System.Drawing.Size(99, 25);
            this.lblNormVal.TabIndex = 48;
            this.lblNormVal.Text = "0";
            this.lblNormVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblminVal
            // 
            this.lblminVal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblminVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblminVal.Location = new System.Drawing.Point(248, 360);
            this.lblminVal.Name = "lblminVal";
            this.lblminVal.Size = new System.Drawing.Size(99, 25);
            this.lblminVal.TabIndex = 49;
            this.lblminVal.Text = "0";
            this.lblminVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxVal
            // 
            this.lblMaxVal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMaxVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMaxVal.Location = new System.Drawing.Point(642, 360);
            this.lblMaxVal.Name = "lblMaxVal";
            this.lblMaxVal.Size = new System.Drawing.Size(99, 25);
            this.lblMaxVal.TabIndex = 50;
            this.lblMaxVal.Text = "0";
            this.lblMaxVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveVal
            // 
            this.btnSaveVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.btnSaveVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveVal.Location = new System.Drawing.Point(668, 194);
            this.btnSaveVal.Name = "btnSaveVal";
            this.btnSaveVal.Size = new System.Drawing.Size(162, 48);
            this.btnSaveVal.TabIndex = 51;
            this.btnSaveVal.Text = "Сохранить";
            this.btnSaveVal.UseVisualStyleBackColor = false;
            this.btnSaveVal.Click += new System.EventHandler(this.btnSaveVal_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.btnSaveVal);
            this.Controls.Add(this.lblMaxVal);
            this.Controls.Add(this.lblminVal);
            this.Controls.Add(this.lblNormVal);
            this.Controls.Add(this.btnClearPack);
            this.Controls.Add(this.cbVolt2V);
            this.Controls.Add(this.cbVolt1V);
            this.Controls.Add(this.cbVolt2M);
            this.Controls.Add(this.cbVolt1M);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.tbMaxPak);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbMinPak);
            this.Controls.Add(this.lblPort2);
            this.Controls.Add(this.lblKoeff);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPort1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbMax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbNorm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbMin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPort1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.cbPort2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(950, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kriterium     V1.90";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox cbPort1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbPort2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNorm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar pbRight;
        private System.Windows.Forms.ProgressBar pbLeft;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblPort1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblKoeff;
        private System.Windows.Forms.Label lblPort2;
        private System.Windows.Forms.TextBox tbMinPak;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbMaxPak;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.CheckBox cbVolt1M;
        private System.Windows.Forms.CheckBox cbVolt2M;
        private System.Windows.Forms.CheckBox cbVolt1V;
        private System.Windows.Forms.CheckBox cbVolt2V;
        private System.Windows.Forms.Button btnClearPack;
        private System.Windows.Forms.Label lblNormVal;
        private System.Windows.Forms.Label lblminVal;
        private System.Windows.Forms.Label lblMaxVal;
        private System.Windows.Forms.Button btnSaveVal;
    }
}

