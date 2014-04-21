using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirMouse.Updates
{
    public partial class DownloadForm : Form
    {
        private String _title;
        private readonly Pen PenBorder;
        int thickness = 4;
        int titleBarThickness = 25;
        bool _click;
        Point _mouseClickLocation;
        Point _controlClickLocation;
        private const string Kb = "Kb";
        private const string Kbs = "Kb/s";
        public event EventHandler OnCancel;

        public DownloadForm(string title)
        {
            PenBorder = new Pen(Color.FromArgb(37, 37, 37), 100);
            _title = title;

            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            _click = true;
            _mouseClickLocation = new Point(MousePosition.X, MousePosition.Y);
            _controlClickLocation = this.Location;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _click = false;


        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_click) return;


            var deltaX = MousePosition.X - _mouseClickLocation.X;
            var deltaY = MousePosition.Y - _mouseClickLocation.Y;
            this.Location = new Point(_controlClickLocation.X + deltaX, _controlClickLocation.Y + deltaY);


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawBorder(e.Graphics);
            DrawTitle(e.Graphics);
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

        private void DrawBorder(Graphics graphics)
        {

            var rectangleCloseButton = new Rectangle(Width - titleBarThickness - 1, 0, titleBarThickness, titleBarThickness);
            var rectangleMinimizeButton = new Rectangle(Width - titleBarThickness * 2, 0, titleBarThickness, titleBarThickness);

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
            var font = new System.Drawing.Font("Arial", 12f, FontStyle.Regular);
            graphics.DrawString(_title, font, Brushes.DimGray, 2, 4);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (OnCancel != null)
                OnCancel(this, null);

            Close();
        }
        private delegate void delegateValues(string speed, string total, string downloaded, string remaining, int? percentage);
        public void SetValues(string speed, string total, string downloaded, string remaining, int? percentage)
        {
            if (InvokeRequired)
            {
                var del = new delegateValues(SetValues);
                Invoke(del, new object[] { speed, total, downloaded, remaining, percentage });

            }
            else
            {
                if (speed!=null)
                {
                    labelSpeed.Text = speed.ToString() + " " + Kbs;
                }
                if (total != null)
                {
                    labelTotalSize.Text = total.ToString() + " " + Kb;
                }
                if (downloaded != null)
                {
                    labelDownloaded.Text = downloaded.ToString() + " " + Kb;
                }
                if (remaining != null)
                {
                    labelRemaining.Text = remaining.ToString() + " " + Kb;
                }
                if (percentage.HasValue)
                {
                    if (percentage <= progressBar1.Maximum)
                        progressBar1.Value = percentage.Value;
                }
            }
        }
    }
}
