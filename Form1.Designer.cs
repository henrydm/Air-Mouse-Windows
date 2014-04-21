namespace AirMouse
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.groupBoxSettingsUpdates = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSettingsStartup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxCheckUpdates = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxRunAtStartUp = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxStartupMinimized = new System.Windows.Forms.CheckBox();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelversion = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.labelInfoInfo = new System.Windows.Forms.Label();
            this.panelConnection = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelManufacturer = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonConnection = new System.Windows.Forms.Button();
            this.panelSettings.SuspendLayout();
            this.groupBoxSettingsUpdates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxSettingsStartup.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelConnection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Indigo;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkLabel1.Location = new System.Drawing.Point(7, 28);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(187, 15);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.androidairmouse.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Clicked);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelSettings.Controls.Add(this.groupBoxSettingsUpdates);
            this.panelSettings.Controls.Add(this.groupBoxSettingsStartup);
            this.panelSettings.Location = new System.Drawing.Point(5, 183);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(378, 108);
            this.panelSettings.TabIndex = 27;
            // 
            // groupBoxSettingsUpdates
            // 
            this.groupBoxSettingsUpdates.Controls.Add(this.numericUpDown1);
            this.groupBoxSettingsUpdates.Controls.Add(this.label1);
            this.groupBoxSettingsUpdates.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSettingsUpdates.Location = new System.Drawing.Point(203, 8);
            this.groupBoxSettingsUpdates.Name = "groupBoxSettingsUpdates";
            this.groupBoxSettingsUpdates.Size = new System.Drawing.Size(170, 100);
            this.groupBoxSettingsUpdates.TabIndex = 4;
            this.groupBoxSettingsUpdates.TabStop = false;
            this.groupBoxSettingsUpdates.Text = "Connection";
            this.groupBoxSettingsUpdates.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 9F);
            this.numericUpDown1.ForeColor = System.Drawing.Color.DarkGray;
            this.numericUpDown1.Location = new System.Drawing.Point(90, 22);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 21);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // groupBoxSettingsStartup
            // 
            this.groupBoxSettingsStartup.Controls.Add(this.label4);
            this.groupBoxSettingsStartup.Controls.Add(this.checkBoxCheckUpdates);
            this.groupBoxSettingsStartup.Controls.Add(this.label3);
            this.groupBoxSettingsStartup.Controls.Add(this.checkBoxRunAtStartUp);
            this.groupBoxSettingsStartup.Controls.Add(this.label2);
            this.groupBoxSettingsStartup.Controls.Add(this.checkBoxStartupMinimized);
            this.groupBoxSettingsStartup.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSettingsStartup.Location = new System.Drawing.Point(10, 6);
            this.groupBoxSettingsStartup.Name = "groupBoxSettingsStartup";
            this.groupBoxSettingsStartup.Size = new System.Drawing.Size(187, 100);
            this.groupBoxSettingsStartup.TabIndex = 3;
            this.groupBoxSettingsStartup.TabStop = false;
            this.groupBoxSettingsStartup.Text = "Startup Settings";
            this.groupBoxSettingsStartup.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(28, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Auto Check Updates";
            // 
            // checkBoxCheckUpdates
            // 
            this.checkBoxCheckUpdates.AutoSize = true;
            this.checkBoxCheckUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.checkBoxCheckUpdates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBoxCheckUpdates.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkBoxCheckUpdates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.checkBoxCheckUpdates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.checkBoxCheckUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxCheckUpdates.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCheckUpdates.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxCheckUpdates.Location = new System.Drawing.Point(10, 68);
            this.checkBoxCheckUpdates.Name = "checkBoxCheckUpdates";
            this.checkBoxCheckUpdates.Size = new System.Drawing.Size(12, 11);
            this.checkBoxCheckUpdates.TabIndex = 2;
            this.checkBoxCheckUpdates.UseVisualStyleBackColor = false;
            this.checkBoxCheckUpdates.Click += new System.EventHandler(this.checkBoxCheckUpdates_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(28, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Startup Minimized";
            // 
            // checkBoxRunAtStartUp
            // 
            this.checkBoxRunAtStartUp.AutoSize = true;
            this.checkBoxRunAtStartUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.checkBoxRunAtStartUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBoxRunAtStartUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkBoxRunAtStartUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.checkBoxRunAtStartUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.checkBoxRunAtStartUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxRunAtStartUp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRunAtStartUp.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxRunAtStartUp.Location = new System.Drawing.Point(10, 23);
            this.checkBoxRunAtStartUp.Name = "checkBoxRunAtStartUp";
            this.checkBoxRunAtStartUp.Size = new System.Drawing.Size(12, 11);
            this.checkBoxRunAtStartUp.TabIndex = 0;
            this.checkBoxRunAtStartUp.UseVisualStyleBackColor = false;
            this.checkBoxRunAtStartUp.CheckedChanged += new System.EventHandler(this.checkBoxRunAtStartUp_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(28, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Run on Windows Startup";
            // 
            // checkBoxStartupMinimized
            // 
            this.checkBoxStartupMinimized.AutoSize = true;
            this.checkBoxStartupMinimized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.checkBoxStartupMinimized.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBoxStartupMinimized.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkBoxStartupMinimized.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.checkBoxStartupMinimized.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.checkBoxStartupMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxStartupMinimized.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStartupMinimized.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxStartupMinimized.Location = new System.Drawing.Point(10, 45);
            this.checkBoxStartupMinimized.Name = "checkBoxStartupMinimized";
            this.checkBoxStartupMinimized.Size = new System.Drawing.Size(12, 11);
            this.checkBoxStartupMinimized.TabIndex = 1;
            this.checkBoxStartupMinimized.UseVisualStyleBackColor = false;
            this.checkBoxStartupMinimized.CheckedChanged += new System.EventHandler(this.checkBoxRunAtStartUp_CheckedChanged);
            // 
            // panelInfo
            // 
            this.panelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panelInfo.AutoScroll = true;
            this.panelInfo.Controls.Add(this.labelversion);
            this.panelInfo.Controls.Add(this.label);
            this.panelInfo.Controls.Add(this.labelInfoInfo);
            this.panelInfo.Controls.Add(this.linkLabel1);
            this.panelInfo.Location = new System.Drawing.Point(5, 297);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(378, 510);
            this.panelInfo.TabIndex = 28;
            // 
            // labelversion
            // 
            this.labelversion.AutoSize = true;
            this.labelversion.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelversion.ForeColor = System.Drawing.Color.Silver;
            this.labelversion.Location = new System.Drawing.Point(197, 9);
            this.labelversion.Name = "labelversion";
            this.labelversion.Size = new System.Drawing.Size(32, 19);
            this.labelversion.TabIndex = 2;
            this.labelversion.Text = "1.0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.Silver;
            this.label.Location = new System.Drawing.Point(6, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(197, 19);
            this.label.TabIndex = 1;
            this.label.Text = "Android Air Mouse Server";
            // 
            // labelInfoInfo
            // 
            this.labelInfoInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelInfoInfo.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoInfo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelInfoInfo.Location = new System.Drawing.Point(7, 69);
            this.labelInfoInfo.Name = "labelInfoInfo";
            this.labelInfoInfo.Size = new System.Drawing.Size(366, 1100);
            this.labelInfoInfo.TabIndex = 0;
            this.labelInfoInfo.Text = "INFO TEXT";
            // 
            // panelConnection
            // 
            this.panelConnection.Controls.Add(this.groupBox1);
            this.panelConnection.Controls.Add(this.groupBox2);
            this.panelConnection.Location = new System.Drawing.Point(5, 28);
            this.panelConnection.Name = "panelConnection";
            this.panelConnection.Size = new System.Drawing.Size(380, 108);
            this.panelConnection.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 105);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STATUS:";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.labelStatus.Location = new System.Drawing.Point(7, 12);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(191, 86);
            this.labelStatus.TabIndex = 19;
            this.labelStatus.Text = "Not Connected";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.labelModel);
            this.groupBox2.Controls.Add(this.labelManufacturer);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox2.Location = new System.Drawing.Point(203, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 105);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DEVICE:";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox_Paint);
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.ForeColor = System.Drawing.Color.DimGray;
            this.labelModel.Location = new System.Drawing.Point(51, 68);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(98, 18);
            this.labelModel.TabIndex = 27;
            this.labelModel.Text = "Not Connected";
            // 
            // labelManufacturer
            // 
            this.labelManufacturer.AutoSize = true;
            this.labelManufacturer.ForeColor = System.Drawing.Color.DimGray;
            this.labelManufacturer.Location = new System.Drawing.Point(7, 38);
            this.labelManufacturer.Name = "labelManufacturer";
            this.labelManufacturer.Size = new System.Drawing.Size(98, 18);
            this.labelManufacturer.TabIndex = 26;
            this.labelManufacturer.Text = "Not Connected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "Model:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "Manufacturer:";
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSettings.BackColor = System.Drawing.Color.DimGray;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.ForeColor = System.Drawing.Color.DarkGray;
            this.buttonSettings.Location = new System.Drawing.Point(132, 539);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(127, 22);
            this.buttonSettings.TabIndex = 30;
            this.buttonSettings.Text = "SETTINGS";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonInfo.BackColor = System.Drawing.Color.DimGray;
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInfo.ForeColor = System.Drawing.Color.DarkGray;
            this.buttonInfo.Location = new System.Drawing.Point(259, 539);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(127, 22);
            this.buttonInfo.TabIndex = 31;
            this.buttonInfo.Text = "INFO";
            this.buttonInfo.UseVisualStyleBackColor = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonConnection
            // 
            this.buttonConnection.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonConnection.BackColor = System.Drawing.Color.DimGray;
            this.buttonConnection.FlatAppearance.BorderSize = 0;
            this.buttonConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.buttonConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnection.ForeColor = System.Drawing.Color.DarkGray;
            this.buttonConnection.Location = new System.Drawing.Point(5, 539);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(127, 22);
            this.buttonConnection.TabIndex = 32;
            this.buttonConnection.Text = "CONNECTION";
            this.buttonConnection.UseVisualStyleBackColor = false;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(390, 565);
            this.Controls.Add(this.buttonConnection);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.panelConnection);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air Mouse Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.panelSettings.ResumeLayout(false);
            this.groupBoxSettingsUpdates.ResumeLayout(false);
            this.groupBoxSettingsUpdates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBoxSettingsStartup.ResumeLayout(false);
            this.groupBoxSettingsStartup.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelConnection.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox checkBoxCheckUpdates;
        private System.Windows.Forms.CheckBox checkBoxStartupMinimized;
        private System.Windows.Forms.CheckBox checkBoxRunAtStartUp;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelversion;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelInfoInfo;
        private System.Windows.Forms.Panel panelConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelManufacturer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.GroupBox groupBoxSettingsUpdates;
        private System.Windows.Forms.GroupBox groupBoxSettingsStartup;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConnection;
    }
}

