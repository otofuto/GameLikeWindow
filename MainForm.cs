using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLikeWindow
{
    public partial class MainForm : Form
    {
        bool nowAnimation = false;

        public MainForm()
        {
            InitializeComponent();

            var viewSize = TextRenderer.MeasureText("はじめる", new Font("@ロンド B スクエア", 40));
            MessageBox.Show(viewSize.Width + ", " + viewSize.Height);
            Image bmp = new Bitmap(viewSize.Width, viewSize.Height);
            var g = Graphics.FromImage(bmp);
            g.DrawLine(new Pen(Color.White, bmp.Height - (float)bmp.Width * 0.14f), 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);
            g.DrawLine(new Pen(Color.White, bmp.Height), bmp.Width * 0.07f, bmp.Height / 2, bmp.Width * 0.93f, bmp.Height / 2);
            g.DrawString("はじめる", new Font("@ロンド B スクエア", 40), new SolidBrush(Color.Black), 0, 0);
            g.Dispose();
            pb1.Image = bmp;
            pb1.Size = new Size(bmp.Width, bmp.Height);
            pb1.Location = new Point((Width - pb1.Width) / 2, (int)(Height * 0.7));
            pb1.SizeMode = PictureBoxSizeMode.Zoom;

            pb1.MouseEnter += new EventHandler(pb1_MouseEnter);
            pb1.MouseLeave += new EventHandler(pb1_MouseLeave);
            pb1.Click += new EventHandler(pb1_Click);
        }

        private void pb1_MouseEnter(object sender, EventArgs e)
        {
            if (nowAnimation) return;
            pb1.Width += 20;
            pb1.Height += 20;
            pb1.Left -= 10;
            pb1.Top -= 10;
        }

        private void pb1_MouseLeave(object sender, EventArgs e)
        {
            if (nowAnimation) return;
            pb1.Width -= 20;
            pb1.Height -= 20;
            pb1.Left += 10;
            pb1.Top += 10;
        }

        private async void pb1_Click(object sender, EventArgs e)
        {
            await StartAnimation(pb1);
            _ = ViewCourse();
        }

        private async Task StartAnimation(PictureBox target)
        {
            nowAnimation = true;
            for(int i = 0; i < 3; i++)
            {
                target.Visible = false;

                await Task.Delay(130);

                target.Visible = true;

                await Task.Delay(130);
            }
            target.Visible = false;
            nowAnimation = false;
        }

        private async Task ViewCourse()
        {
            var pbs = new PictureBox[4];
            for(int i = 0; i < pbs.Length; i++)
            {
                pbs[i] = new PictureBox();
            }
        }
    }
}
