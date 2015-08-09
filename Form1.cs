/********************************************************************************************
*	Copyright(C) 2014  Enric del Molino 													*
*	http://www.androidairmouse.com															*
*	enricdelmolino@gmail.com																*
*																							*
*	This file is part of Air Mouse Server for Windows.										*
*																							*
*   Air Mouse Server for Windows is free software: you can redistribute it and/or modify	*
*   it under the terms of the GNU General Public License as published by					*
*   the Free Software Foundation, either version 3 of the License, or						*
*   (at your option) any later version.														*
*																							*
*   Air Mouse Server for Windows is distributed in the hope that it will be useful,			*
*   but WITHOUT ANY WARRANTY; without even the implied warranty of							*
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the							*
*   GNU General Public License for more details.											*
*																							*
*   You should have received a copy of the GNU General Public License						*
*   along with Air Mouse Server for Windows.  If not, see <http://www.gnu.org/licenses/>.	*
********************************************************************************************/

using AirMouse.Updates;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirMouse
{
    public partial class Form1 : Form
    {
        #region Definitions
        private enum MessageType { Data, Close, Hello, Bye, Unset };
        private enum PanelActive { Connection, Settings, Info };

        private delegate void delegateStringColor(string text, Color? color);
        private delegate void delegateString(string text);
        private delegate void delegateTwoStringColor(string text1, string text2, Color? color);
        private delegate void delegateVoid();

        private NotifyIcon _trayIcon;
        private ContextMenu _trayMenu;

        private float _x, _y;
        string _decimalSeparator;
        private int _port = 6000, _inactivityTime = 10000;
        private const float MIN_MOV = 0.035f;
        private BackgroundWorker _bw;
        bool _on = true;
        bool _modifyngUI;

        private string _manufacturerName, _modelName;
        bool _click;
        Point _mouseClickLocation;
        Point _controlClickLocation;

        int thickness = 4;
        int titleBarThickness = 25;

        Rectangle rectangleCloseButton;
        Rectangle rectangleMinimizeButton;

        bool _overMinimize, _overClose, _silent;

        private const String IdleText = "Waiting for connections";
        private const String ConnectedText = "Connected";

        private readonly Color ColorConnected;
        private readonly Color ColorIdle;
        private readonly Color ColorDeviceConnected;
        private readonly Color ColorDeviceIdle;
        private readonly Color ColorButtonActive;
        private readonly Color ColorButtonInActive;
        private readonly Color ColorButtonOver;
        private readonly Color ColorBorder;
        private readonly Pen PenBorder;

        private String InfoText;

        private const String KeyFirstLoad = "FirstLoad";
        private const String KeyAutoUpdate = "AutoUpdates";
        private const String KeyPort = "Port";
        private const String KeyCurrentPath = "CurrentPath";
        private const String KeyNewUpdateDownloaded = "NewUpdateDownloaded";
        bool _runMinimized;
        #endregion

        private void SetInfoText()
        {
            labelversion.Text = Application.ProductVersion;

            InfoText = "You have to be installed Android Air Mouse for Android in your android phone, to run this application correctly, you can download directly from the Google Play or from http://www.androidairmouse.com." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += "To pair your divice with this application just keep this program running and open Android Air Mouse app from you android phone, it should connect automatically." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += "POSSIBLE CAUSES OF NOT SUCCESSFULLY CONNECTIONS:";
            InfoText += System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += "-Cause: Your computer and your android phone must be connected to the same Wifi network." + System.Environment.NewLine;
            InfoText += "-Solution: connect your phone to this network :)." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += "-Cause: You clicked on \"Don't allow this program to connect to Internet\"" + System.Environment.NewLine; ;
            InfoText += "-Solution: the server is not able to receive any data from your smart phone, you should follow next steps:" + System.Environment.NewLine;
            InfoText += "Go to Start --> Control Panel --> View Network status and tasks --> Windows Firewall --> Allow a program or feature through Windows Firewall." + System.Environment.NewLine; ;
            InfoText += "Click on \"Change Settings\"  and check the " + Application.ProductName + "checkbox (At least Home/Work (Private) option)." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += "-Cause: An other Firewall (like Zone Alarm, CyberOAM...) or Antivirus software (like Karsperki, Panda, Avg...) is blocking " + Application.ProductName + System.Environment.NewLine;
            InfoText += "-Solution: Often AntiVirus suites  includes a firewall software which could block automatically Ingoing/Outgoing connections, in this case you would have to set up your Antivirus or Firewall to allow " + Application.ProductName + " to get access to the network." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += "-Cause: A hardware firewall is blocking Incoming/Outgoing connections." + System.Environment.NewLine; ;
            InfoText += "-Solution: Vitrually all home routers have an integrated firewall, by default it's disabled but if you have it enabled, you must set a rule for your phone IP and your PC IP and it's port (which by default is 6000), if you're in a university net, or a big company probably all intranet trafic is managed by a proxy server (Squirt proxy) so talk to IT guy, it's your best choice in this case." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += Application.ProductName + " is Open Source (Windows server and Android client) so that means that you can download the source code, redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += Application.ProductName + " for Windows and Android is COMPLETELY FREE and has NO ADs, which means I do not earn a fucking euro with this." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += Application.ProductName + " for Windows and Android is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY, without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE." + System.Environment.NewLine; ;
            InfoText += "See the  GNU General Public License for more details." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += "This is a RC1 (Release Candidate) version, I fixed a lot of bugs from the beta version, but if you found any bug or you have any suggestion, plase feel free to write me at enricdelmolino@gmail.com" + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += "This program was made with all my love, I hope it be useful for you, and you enjoy it." + System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += System.Environment.NewLine;
            InfoText += "Enric.";

            labelInfoInfo.Text = InfoText;

        }

        //Constructor
        public Form1(bool runMinimized)
        {
            _runMinimized = runMinimized;
            ColorBorder = Color.FromArgb(37, 37, 37);
            ColorConnected = Color.ForestGreen;
            ColorIdle = Color.DarkOliveGreen;
            ColorDeviceConnected = Color.OliveDrab;
            ColorDeviceIdle = Color.DimGray;
            ColorButtonActive = Color.FromArgb(76, 76, 76);
            ColorButtonInActive = Color.FromArgb(95, 95, 95);
            ColorButtonOver = Color.FromArgb(120, 120, 120);
            PenBorder = new Pen(ColorBorder, 100);

            FirstTimeRoutine();

            InitializeComponent();


            System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            _decimalSeparator = ci.NumberFormat.CurrencyDecimalSeparator;
            _bw = new BackgroundWorker();

            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;

            _bw.DoWork += _bw_DoWork;

            // Create a simple tray menu with only one item.
            _trayMenu = new ContextMenu();
            _trayMenu.MenuItems.Add("Close", Exit);


            _trayIcon = new NotifyIcon();
            _trayIcon.Text = Application.ProductName;
            _trayIcon.Icon = Properties.Resources.ico_tray_ico100;
            _trayIcon.BalloonTipTitle = Application.ProductName;

            _trayIcon.ContextMenu = _trayMenu;
            _trayIcon.Visible = false;

            _trayIcon.MouseClick += (o, e) => { this.Show(); WindowState = FormWindowState.Normal; };

            LocatePanels();
            SetInfoText();

        }



        #region Form Events
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            SetInitialSize();
            SetPanel(PanelActive.Connection);
            SetDisconnectedInfoToUI();
            _bw.RunWorkerAsync();

            if (_runMinimized)
            {
                _silent = true;
                WindowState = FormWindowState.Minimized;
                _silent = false;
            }
        }
        private void frmMain_Resize(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Minimized)
            {
                _trayIcon.Visible = true;
                if (!_silent)
                {
                    _trayIcon.BalloonTipText = String.Format("{0} will keep running, to show up back, click on this icon", Application.ProductName);
                    _trayIcon.ShowBalloonTip(500);
                }
                ShowInTaskbar = false;
                this.Hide();

            }

            else if (WindowState == FormWindowState.Normal)
            {
                _trayIcon.Visible = false;
                ShowInTaskbar = true;


            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _trayIcon.Visible = false;
            _trayIcon.Dispose();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_overClose || _overMinimize) return;
            _click = true;
            _mouseClickLocation = new Point(MousePosition.X, MousePosition.Y);
            _controlClickLocation = this.Location;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _click = false;

            if (_overClose)
                Close();

            if (_overMinimize)
            {
                _overMinimize = false;
                WindowState = FormWindowState.Minimized;
            }

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //Minimize Button
            if (e.X > rectangleMinimizeButton.Location.X && e.X < rectangleMinimizeButton.Location.X + rectangleMinimizeButton.Size.Width && e.Y > rectangleMinimizeButton.Location.Y && e.Y < rectangleMinimizeButton.Location.Y + rectangleMinimizeButton.Size.Height)
            {
                if (!_overMinimize)
                {
                    _overMinimize = true;
                    Refresh();
                }
            }
            else
            {
                if (_overMinimize)
                {
                    _overMinimize = false;
                    Refresh();
                }
            }

            //Close Button
            if (e.X > rectangleCloseButton.Location.X && e.X < rectangleCloseButton.Location.X + rectangleCloseButton.Size.Width && e.Y > rectangleCloseButton.Location.Y && e.Y < rectangleCloseButton.Location.Y + rectangleCloseButton.Size.Height)
            {
                if (!_overClose)
                {
                    _overClose = true;
                    Refresh();
                }
            }
            else
            {
                if (_overClose)
                {
                    _overClose = false;
                    Refresh();
                }
            }

            if (!_click) return;


            var deltaX = MousePosition.X - _mouseClickLocation.X;
            var deltaY = MousePosition.Y - _mouseClickLocation.Y;
            this.Location = new Point(_controlClickLocation.X + deltaX, _controlClickLocation.Y + deltaY);


        }
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            Form1_MouseMove(this, new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, -1, -1, 0));
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e.Graphics);
            DrawButtons(e.Graphics);
            DrawTitle(e.Graphics);
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            SetPanel(PanelActive.Connection);
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SetPanel(PanelActive.Settings);
        }
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            SetPanel(PanelActive.Info);
        }

        private void linkLabel_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.androidairmouse.com");
        }

        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = (GroupBox)sender;

            e.Graphics.Clear(this.BackColor);

            var pen = new Pen(Color.DimGray, 3);

            var textSize = e.Graphics.MeasureString(box.Text, box.Font);
            e.Graphics.DrawString(box.Text, box.Font, Brushes.Gray, 10, 0);
            e.Graphics.DrawLine(pen, 4, 10, 10, 10);
            e.Graphics.DrawLine(pen, 10 + textSize.Width, 10, box.Width - 6, 10);
            e.Graphics.DrawLine(pen, box.Width - 6, 9, box.Width - 6, box.Height - 10);
            e.Graphics.DrawLine(pen, box.Width - 4, box.Height - 10, 4, box.Height - 10);
            e.Graphics.DrawLine(pen, 4, 10, 4, box.Height - 8);
        }

        private void checkBoxRunAtStartUp_CheckedChanged(object sender, EventArgs e)
        {
            if (_modifyngUI) return;

            _modifyngUI = true;

            if (sender == checkBoxStartupMinimized)
            {
                if (checkBoxStartupMinimized.Checked)
                    checkBoxRunAtStartUp.Checked = true;
            }

            if (sender == checkBoxRunAtStartUp)
            {
                if (!checkBoxRunAtStartUp.Checked)
                    checkBoxStartupMinimized.Checked = false;
            }

            _modifyngUI = false;

            SetRunAtStartUp(checkBoxRunAtStartUp.Checked, checkBoxStartupMinimized.Checked);
        }
        private void checkBoxCheckUpdates_Click(object sender, EventArgs e)
        {

        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (_modifyngUI) return;

            var keyStrSettings = "SOFTWARE\\" + Application.ProductName;
            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey(keyStrSettings, true);
            if (keySettings != null)
            {
                keySettings.SetValue(KeyPort, numericUpDown1.Value.ToString());
                _port = Convert.ToInt32(numericUpDown1.Value);
            }
        }

        #endregion

        #region Compute data
        void _bw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (_on)
            {


                ReceiveDataLoop();


            }

        }

        void ReceiveDataLoop()
        {
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, _port);
            UdpClient udpClient = null;
            byte[] bytes;
            string inputData;
            MessageType msgType;

            while (_on)
            {
                //Listen for incomming connections
                if (udpClient == null)
                {
                    var listener = TcpListener.Create(_port);
                    listener.Start();

                    var tcpClient = listener.AcceptTcpClient();
                    bytes = new byte[tcpClient.ReceiveBufferSize];

                    var stream = tcpClient.GetStream();
                    stream.Read(bytes, 0, tcpClient.ReceiveBufferSize);

                    inputData = Encoding.UTF8.GetString(bytes);

                    msgType = ComputeReceivedData(inputData);

                    if (msgType == MessageType.Hello)
                    {
                        udpClient = new UdpClient(_port);

                        var answer = Encoding.ASCII.GetBytes("que ase");
                        stream.Write(answer, 0, answer.Length);

                        stream.Close();
                        stream.Dispose();
                        tcpClient.Close();
                        listener.Stop();

                        SetConnectionInfoToUI(inputData);
                    }
                   
                }

                //Connection Loop
               // udpClient.Client.ReceiveTimeout = _inactivityTime;
                try
                {
                    bytes = udpClient.Receive(ref groupEP);
                    inputData = Encoding.UTF8.GetString(bytes);

                    msgType = ComputeReceivedData(inputData);
                    if (msgType == MessageType.Bye)
                    {
                        SetDisconnectedInfoToUI();
                        udpClient.Close();
                        udpClient = null;
                    }
                }

                //On time out
                catch (SocketException)
                {
                    if (udpClient != null)
                        udpClient.Close();

                    udpClient = null;
                }

            }
        }

        private MessageType ComputeReceivedData(string receivedData)
        {

            string[] splitedData = (receivedData.Split('|'));


            if (receivedData == "keyboard||")
                splitedData = new[] { "keyboard", "|" };


            if (splitedData.Count() == 1)
            {

                if (splitedData[0] == "hola")
                {
                    return MessageType.Hello;
                }
                else if (splitedData[0] == "adeu")
                {
                    return MessageType.Bye;
                }
                else if (splitedData[0] == "close")
                {
                    return MessageType.Close;
                }
                else if (splitedData[0] == "delete")
                {
                    SendKeys.SendWait("{BACKSPACE}");
                }
                else if (splitedData[0] == "enter")
                {
                    SendKeys.SendWait("{ENTER}");
                }
            }

            if (splitedData.Count() == 2)
            {
                string splitedDataX = splitedData[0];
                string splitedDataY = splitedData[1];

                if (splitedDataX == "keyboard")
                {
                    splitedDataY = splitedDataY.Replace("+", "{+}");
                    splitedDataY = splitedDataY.Replace("^", "{^}");
                    splitedDataY = splitedDataY.Replace("%", "{%}");
                    splitedDataY = splitedDataY.Replace("~", "{~}");
                    splitedDataY = splitedDataY.Replace("(", "{(}");
                    splitedDataY = splitedDataY.Replace(")", "{)}");

                    SendKeys.SendWait(splitedDataY);
                    
                }

                else if (splitedDataX == "hola")
                {
                    return MessageType.Hello;
                }

                float floatX, floatY;
                if (float.TryParse(splitedDataX, out floatX) && float.TryParse(splitedDataY, out floatY))
                {
                    _x = floatX;
                    _y = floatY;
                }

                if (splitedDataX == "volume")
                {
                    if (splitedDataY == "down")
                        VolumeDown();

                    else if (splitedDataY == "up")
                        VolumeUP();
                }

                else if (splitedDataX == "down")
                {
                    if (splitedDataY == "left")
                        MousePrimaryDown();

                    else if (splitedDataY == "right")
                        MouseSecondaryDown();
                }

                else if (splitedDataX == "up")
                {
                    if (splitedDataY == "left")
                        MousePrimaryUp();

                    else if (splitedDataY == "right")
                        MouseSecondaryUp();
                }

                else if (splitedDataX == "wheel")
                {
                    if (splitedDataY == "up")
                    {
                        MouseWheelClick();
                    }

                    else if (String.Empty != splitedDataY)
                    {
                        splitedDataY = splitedDataY.Replace(".", _decimalSeparator);
                        float delta;
                        if (float.TryParse(splitedDataY, out delta))
                        {
                            MousewheelScroll(Convert.ToInt32(delta));
                        }
                    }
                }
                else if (splitedDataX == "zoom")
                {
                    float delta;
                    if (float.TryParse(splitedDataY, out delta))
                    {
                        MousewheelZoom(Convert.ToInt32(delta));
                    }
                }
                else
                {
                    splitedDataX = splitedDataX.Replace(".", _decimalSeparator);
                    splitedDataY = splitedDataY.Replace(".", _decimalSeparator);
                    double splitedDataXF, splitedDataYF;
                    var currentX = Cursor.Position.X;
                    var currentY = Cursor.Position.Y;
                    int incX = 0;
                    int incY = 0;


                    if (double.TryParse(splitedDataX, out splitedDataXF))
                    {
                        if (Math.Abs(splitedDataXF) > MIN_MOV)
                        {
                            incX = (int)(splitedDataXF);
                            currentX += incX;
                        }
                    }

                    if (double.TryParse(splitedDataY, out splitedDataYF))
                    {
                        if (Math.Abs(splitedDataYF) > MIN_MOV)
                        {
                            incY = (int)(splitedDataYF);
                            currentY += incY;
                        }
                    }

                    Cursor.Position = new Point(currentX, currentY);
                }
                return MessageType.Data;
            }

            return MessageType.Unset;
        }
        #endregion

        #region Private Methods

        private void CheckUpdates()
        {
            var bw = new BackgroundWorker();

            bw.DoWork += (o, e) =>
            {
                try
                {
                    var latestVersionPublished = NetUtils.GetLatestVersionPublished();
                    var currentVerstionStr = Application.ProductVersion.Replace(".", "");
                    var currentVersion = Convert.ToUInt32(currentVerstionStr);

                    if (latestVersionPublished > currentVersion)
                    {
                        e.Result = true;
                    }
                    else
                    {
                        e.Result = false;
                    }
                }
                catch
                {
                    e.Result = false;
                }
            };
            bw.RunWorkerCompleted += (o, e) =>
            {

                if (e.Result != null && e.Result is bool)
                {
                    if ((bool)e.Result)
                        ShowUpdateFormThreadSafe();
                }

            };
            bw.RunWorkerAsync();
        }

        private void ShowUpdateFormThreadSafe()
        {
            if (InvokeRequired)
            {
                var del = new delegateVoid(ShowUpdateFormThreadSafe);
                Invoke(del);
            }
            else
            {
                var msg = new MessageForm("Air Mouse Update", "There is a new update available do you want to download now?");

                if (msg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    DownloadNewVersion();
                }

            }
        }
        private void DownloadNewVersion()
        {
            if (File.Exists(NetUtils.DownloadedTargetTempPath))
            {
                File.Delete(NetUtils.DownloadedTargetTempPath);
            }

            var downloadForm = new DownloadForm("Download Update");
            downloadForm.OnCancel += (o, e) =>
            {
                NetUtils.Cancel();
            };

            NetUtils.OnProgressChanged += (o, e) =>
            {
                downloadForm.SetValues(e.CurrentSpeed, e.TotalSize, e.TotalDownloaded, e.Remaining, e.CurrentPercentage);
            };
            NetUtils.OnError += (o, e) =>
            {

            };
            NetUtils.OnDownloadCompleted += (o, e) =>
            {
                downloadForm.Close();
                ApplyUpdate();

            };
            downloadForm.Show(this);
            NetUtils.DownloadLatestVersion();

        }

        private void ApplyUpdate()
        {
            var scriptFilePath = Path.Combine(Path.GetTempPath(), "AirmouseScript.bat");
            var appTargetFolder = Path.GetDirectoryName(Application.ExecutablePath);
            var appTargetName = Path.GetFileName(Application.ExecutablePath);
            var appTempFolder = Path.GetDirectoryName(NetUtils.DownloadedTargetTempPath);
            var appTempName = Path.GetFileName(NetUtils.DownloadedTargetTempPath);
            var appTargetPathWithTempName = Path.Combine(appTargetFolder, appTempName);
            var w = File.CreateText(scriptFilePath);
            w.WriteLine("@echo off");
            w.WriteLine("timeout 1");
            w.WriteLine("del " + "\"" + Application.ExecutablePath + "\"");
            w.WriteLine("copy " + "\"" + NetUtils.DownloadedTargetTempPath + "\" " + "\"" + appTargetFolder + "\"");
            w.WriteLine("ren " + "\"" + appTargetPathWithTempName + "\" " + "\"" + appTargetName + "\"");
            w.WriteLine("del " + "\"" + NetUtils.DownloadedTargetTempPath + "\"");
            w.WriteLine("start " + "\"" + appTargetFolder + "\" " + "\"" + appTargetName + "\"");

            w.Close();
            w.Dispose();

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(scriptFilePath);
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.Start();
            Application.Exit();


        }
        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void WriteStatusText(string text, Color? color = null)
        {
            if (this.InvokeRequired)
            {
                var del = new delegateStringColor(WriteStatusText);
                this.Invoke(del, new Object[] { text, color });
            }
            else
            {
                labelStatus.Text = text;
                if (color != null && color.HasValue)
                    labelStatus.ForeColor = color.Value;
            }
        }
        private void WriteDeviceInfoText(string manufacturer, string model, Color? color = null)
        {
            if (this.InvokeRequired)
            {
                var del = new delegateTwoStringColor(WriteDeviceInfoText);
                this.Invoke(del, new Object[] { manufacturer, model, color });
            }
            else
            {
                labelManufacturer.Text = manufacturer;
                labelModel.Text = model;
                if (color != null && color.HasValue)
                {
                    labelManufacturer.ForeColor = color.Value;
                    labelModel.ForeColor = color.Value;
                }
            }
        }
        private void SetConnectionInfoToUI(string data)
        {
            WriteStatusText(ConnectedText, ColorConnected);
            if (String.IsNullOrEmpty(data)) return;


            _manufacturerName = "UNKNOWN";
            _modelName = "UNKNOWN";

            string[] splitedData = (data.Split('|'));

            if (splitedData.Length == 2)
            {
                splitedData = (splitedData[1].Split('#'));
                if (splitedData.Length == 2)
                {
                    _manufacturerName = splitedData[0].ToUpperInvariant();
                    _modelName = splitedData[1].ToUpperInvariant();

                }

            }
            WriteDeviceInfoText(_manufacturerName, _modelName, ColorDeviceConnected);
            if (WindowState == FormWindowState.Minimized)
            {
                _trayIcon.BalloonTipText = String.Format("{0} {1} Connected", _manufacturerName, _modelName);
                _trayIcon.ShowBalloonTip(500);
            }

        }
        private void SetDisconnectedInfoToUI()
        {
            if (this.InvokeRequired)
            {
                var del = new delegateVoid(SetDisconnectedInfoToUI);
                this.Invoke(del);
            }
            else
            {
                WriteStatusText(IdleText, ColorIdle);
                WriteDeviceInfoText("Not Connected", "Not Connected", ColorDeviceIdle);

            }
            if (WindowState == FormWindowState.Minimized)
            {
                _trayIcon.BalloonTipText = String.Format("{0} {1} Disconnected", _manufacturerName, _modelName);
                _trayIcon.ShowBalloonTip(500);
            }
        }
        private void SetRunAtStartUp(bool runAtStartUp, bool runMinimized)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (runAtStartUp)
            {
                string args = String.Empty;
                if (runMinimized)
                    args = " -minimized";

                registryKey.SetValue(Application.ProductName, "\"" + Application.ExecutablePath + "\"" + args);
            }
            else
            {
                if (registryKey.GetValue(Application.ProductName) != null)
                    registryKey.DeleteValue(Application.ProductName);
            }
        }
        private void SetSettingsValuesToUI()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
            _modifyngUI = true;
            var value = registryKey.GetValue(Application.ProductName);
            var valStr = value as string;

            //Auto Run
            if (valStr != null)
            {
                checkBoxRunAtStartUp.Checked = true;

                if (valStr.EndsWith("minimized"))
                    checkBoxStartupMinimized.Checked = true;
            }
            else
            {
                checkBoxStartupMinimized.Checked = false;
                checkBoxRunAtStartUp.Checked = false;
            }

            //Check Updates
            var keyStrSettings = "SOFTWARE\\" + Application.ProductName;
            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey(keyStrSettings, false);
            if (keySettings != null)
            {
                var updatesObj = keySettings.GetValue(KeyAutoUpdate);
                var updatesStr = updatesObj as String;
                if (updatesObj != null)
                {
                    checkBoxCheckUpdates.Checked = updatesStr.ToLower() == "true";
                }

            }

            //Port
            numericUpDown1.Value = _port;

            _modifyngUI = false;
        }

        private void FirstTimeRoutine()
        {

            CheckUpdates();

            var keyStrSettings = "SOFTWARE\\" + Application.ProductName;
            RegistryKey keySettings = Registry.CurrentUser.OpenSubKey(keyStrSettings, true);
            if (keySettings == null)
            {
                Registry.CurrentUser.CreateSubKey(keyStrSettings);
                keySettings = Registry.CurrentUser.OpenSubKey(keyStrSettings, true);
            }

            //Set Default settings
            if (keySettings.GetValue(KeyFirstLoad) == null)
            {
                keySettings.SetValue(KeyAutoUpdate, true);
                keySettings.SetValue(KeyFirstLoad, false);
                keySettings.SetValue(KeyPort, _port);

                RegistryKey registryRun = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                registryRun.SetValue(Application.ProductName, "\"" + Application.ExecutablePath + "\"" + " -minimized");
            }


            //Get and set the current port
            var portObj = keySettings.GetValue(KeyPort);
            var portStr = portObj as String;
            if (portStr != null)
            {
                int port;
                if (Int32.TryParse(portStr, out port))
                {
                    if (port > 0 && port < ushort.MaxValue)
                    {
                        _port = port;
                    }
                }
            }


            var newUpdateDownloadedObj = keySettings.GetValue(KeyNewUpdateDownloaded);
            var newUpdateDownloadedStr = newUpdateDownloadedObj as string;
            if (newUpdateDownloadedStr != null && newUpdateDownloadedStr.ToLower() == "true")
            {
                //Check the last path
                var lastPath = keySettings.GetValue(KeyCurrentPath);
            }

            //Current Path
            keySettings.SetValue(KeyCurrentPath, Application.ExecutablePath);

        }

        private void DrawButtons(Graphics graphics)
        {
            if (_overClose)
                graphics.DrawImage(Properties.Resources.ButtonCloseOver, rectangleCloseButton);
            else
                graphics.DrawImage(Properties.Resources.ButtonClose, rectangleCloseButton);

            if (_overMinimize)
                graphics.DrawImage(Properties.Resources.ButtonMinimizeOver, rectangleMinimizeButton);
            else
                graphics.DrawImage(Properties.Resources.ButtonMinimize, rectangleMinimizeButton);
        }
        private void DrawBorder(Graphics graphics)
        {

            rectangleCloseButton = new Rectangle(Width - titleBarThickness - 1, 0, titleBarThickness, titleBarThickness);
            rectangleMinimizeButton = new Rectangle(Width - titleBarThickness * 2, 0, titleBarThickness, titleBarThickness);

            var pLeftUp1 = new Point(0, 0);
            var pLeftUp2 = new Point(thickness, thickness);

            var pRightUp1 = new Point(Width, 0);
            var pRightUp2 = new Point(Width - thickness, thickness);

            var pLeftDown1 = new Point(0, Height);
            var pLeftDown2 = new Point(thickness, Height - thickness);

            var pRightDown1 = new Point(Width, Height);
            var pRightDown2 = new Point(Width - thickness, Height - thickness);

            //UP
            var pathUp = new System.Drawing.Drawing2D.GraphicsPath();
            pathUp.AddLines(new[] { pLeftUp1, new Point(0, titleBarThickness), new Point(Width, titleBarThickness), pRightUp1 });

            //Left
            var pathLeft = new System.Drawing.Drawing2D.GraphicsPath();
            pathLeft.AddLines(new[] { pLeftUp1, pLeftUp2, pLeftDown2, pLeftDown1 });

            //Bottom
            var pathBottom = new System.Drawing.Drawing2D.GraphicsPath();
            pathBottom.AddLines(new[] { pLeftDown1, pLeftDown2, pRightDown2, pRightDown1 });

            //Right
            var pathRight = new System.Drawing.Drawing2D.GraphicsPath();
            pathRight.AddLines(new[] { pRightDown1, pRightDown2, pRightUp2, pRightUp1 });

            //External Up
            graphics.SetClip(pathUp);
            graphics.DrawLine(PenBorder, pLeftUp1, pRightUp1);

            //External Left
            graphics.SetClip(pathLeft);
            graphics.DrawLine(PenBorder, pLeftUp1, pLeftDown1);

            //External Bottom
            graphics.SetClip(pathBottom);
            graphics.DrawLine(PenBorder, pLeftDown1, pRightDown1);

            //External Right
            graphics.SetClip(pathRight);
            graphics.DrawLine(PenBorder, pRightUp1, pRightDown1);


            graphics.ResetClip();
        }
        private void DrawTitle(Graphics graphics)
        {
            graphics.ResetClip();

            var rectIco = new Rectangle(4, 2, titleBarThickness - 4, titleBarThickness - 4);
            graphics.DrawIcon(Properties.Resources.ico_tray_ico100, rectIco);

            var font = new System.Drawing.Font("Arial", 12f, FontStyle.Regular);

            graphics.DrawString(Application.ProductName + " for Android", font, Brushes.DimGray, titleBarThickness + 2, 4);
        }

        private void SetPanel(PanelActive panel)
        {
            panelConnection.Visible = false;
            panelSettings.Visible = false;
            panelInfo.Visible = false;

            buttonConnection.BackColor = ColorButtonInActive;
            buttonSettings.BackColor = ColorButtonInActive;
            buttonInfo.BackColor = ColorButtonInActive;

            buttonConnection.FlatAppearance.MouseOverBackColor = ColorButtonOver;
            buttonSettings.FlatAppearance.MouseOverBackColor = ColorButtonOver;
            buttonInfo.FlatAppearance.MouseOverBackColor = ColorButtonOver;
            switch (panel)
            {
                case PanelActive.Connection:
                    panelConnection.Visible = true;
                    buttonConnection.BackColor = ColorButtonActive;
                    buttonConnection.FlatAppearance.MouseOverBackColor = ColorButtonActive;
                    SetInitialSize();
                    break;
                case PanelActive.Settings:
                    panelSettings.Visible = true;
                    buttonSettings.BackColor = ColorButtonActive;
                    buttonSettings.FlatAppearance.MouseOverBackColor = ColorButtonActive;
                    SetInitialSize();
                    SetSettingsValuesToUI();
                    break;
                case PanelActive.Info:
                    panelInfo.Visible = true;
                    buttonInfo.BackColor = ColorButtonActive;
                    buttonInfo.FlatAppearance.MouseOverBackColor = ColorButtonActive;
                    SetInfoSize();
                    panelInfo.Focus();
                    break;
            }
        }
        private void LocatePanels()
        {
            panelSettings.Location = panelConnection.Location;
            panelInfo.Location = panelConnection.Location;
        }

        private void SetInitialSize()
        {
            var size = new Size(390, 165);
            this.Size = size;
            Refresh();
        }
        private void SetInfoSize()
        {
            var size = new Size(390, 500);
            this.Size = size;
            Refresh();
        }
        #endregion

        #region Mouse Event Simulation
        private const int LEFTDOWN = 0x02;
        private const int LEFTUP = 0x04;
        private const int RIGHTDOWN = 0x08;
        private const int RIGHTUP = 0x10;
        private const int WHEEL_DOWN = 0x20;
        private const int WHEEL_UP = 0x40;
        private const int WHEEL_SCROLL = 0x800;
        private const int KEY_DOWN_EVENT = 0x01; 
        private const int KEY_UP_EVENT = 0x02; 
        private const int KEY_CTRL = 0xA2;
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private void MousePrimaryDown()
        {
            mouse_event(SystemInformation.MouseButtonsSwapped ? RIGHTDOWN : LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }
        private void MousePrimaryUp()
        {
            mouse_event(SystemInformation.MouseButtonsSwapped ? RIGHTUP : LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        private void MouseSecondaryDown()
        {
            mouse_event(SystemInformation.MouseButtonsSwapped ? LEFTDOWN : RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }
        private void MouseSecondaryUp()
        {
            mouse_event(SystemInformation.MouseButtonsSwapped ? LEFTUP : RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        private void MousewheelDown()
        {
            mouse_event(WHEEL_DOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }
        private void MousewheelUp()
        {
            mouse_event(WHEEL_UP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }
        private void MouseWheelClick()
        {
            MousewheelDown();
            MousewheelUp();
        }

        private void MousewheelScroll(int scrollValue)
        {
            mouse_event(WHEEL_SCROLL, Cursor.Position.X, Cursor.Position.Y, scrollValue, 0);
        }
        private void MousewheelZoom(int scrollValue)
        {
            keybd_event(KEY_CTRL, 0x45, KEY_DOWN_EVENT | 0, 0);
            mouse_event(WHEEL_SCROLL, Cursor.Position.X, Cursor.Position.Y, scrollValue, 0);
            keybd_event(KEY_CTRL, 0x45, KEY_DOWN_EVENT | KEY_UP_EVENT, 0);        
        }
        #endregion

        #region Volume Control
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        private void VolumeDown()
        {
            keybd_event((byte)Keys.VolumeDown, 0, 0, 0);
        }
        private void VolumeUP()
        {
            keybd_event((byte)Keys.VolumeUp, 0, 0, 0);
        }
        #endregion

    }
}
