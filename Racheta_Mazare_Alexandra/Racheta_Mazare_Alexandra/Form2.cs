using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racheta_Mazare_Alexandra
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            laser.Visible = false;

        }
        int speed = 10;
        bool right = false;
        public static string SetValueForText1 = "";
        bool left = false;
        bool up = false;
        bool down = false;
        int puncte = 100;
        bool ap1 = false;
        bool ap2 = false;
        bool ap3 = false;
        int timp = 0;
        bool l = false;
        bool ap4 = false;
        bool space = false;
        Random random = new Random();
        Random random1 = new Random();
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion

        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) up = true;
            if (e.KeyCode == Keys.Left) left = true;
            if (e.KeyCode == Keys.Right) right = true;
            if (e.KeyCode == Keys.Down) down = true;
            if (e.KeyCode == Keys.Space) space = true;
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up) up = false;
            if (e.KeyCode == Keys.Left) left = false;
            if (e.KeyCode == Keys.Right) right = false;
            if (e.KeyCode == Keys.Down) down = false;
            if (e.KeyCode == Keys.Space) space = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_puncte.Text = Convert.ToString(puncte);
            if (down && player.Top <= 424)
                player.Top += 10;
            if (up && player.Top >= 11)
                player.Top -= 10;
            if (right && player.Left <= 381)
                player.Left += 10;
            if (left && player.Left >= 95)
                player.Left -= 10;
            if (space)
            {
                laser.Visible = true;
                laser.Location = new Point(player.Location.X + 10, player.Location.Y);
                l = true;
            }
            if (l && laser.Top >= 11)
            {
                laser.Top -= 10;
                if (laser.Bounds.IntersectsWith(a1.Bounds) && a1.Visible == true)
                {
                    ap1 = false;
                    a1.Visible = false;
                    a1.Location = new Point(95, -10);
                    l = false;
                    laser.Visible = false;
                }
                if (laser.Bounds.IntersectsWith(a2.Bounds) && a2.Visible == true)
                {
                    ap2 = false;
                    a2.Visible = false;
                    a2.Location = new Point(95, -10);
                    l = false;
                    laser.Visible = false;
                }
                if (laser.Bounds.IntersectsWith(a3.Bounds) && a3.Visible == true)
                {
                    ap3 = false;
                    a3.Visible = false;
                    a3.Location = new Point(95, -10);
                    l = false;
                    laser.Visible = false;
                }
                if (laser.Bounds.IntersectsWith(a4.Bounds) && a4.Visible == true)
                {
                    ap4 = false;
                    a4.Visible = false;
                    a4.Location = new Point(95, -10);
                    l = false;
                    laser.Visible = false;
                }
            }
            if (l && laser.Top == 3)
                laser.Visible = false;
            if (puncte == 0)
            {
                timer1.Stop();
                timer2.Stop();
                Form3 form = new Form3();
                SetValueForText1 = lbl_timp.Text;
                form.Show();
                this.Hide();
            }
            if (player.Bounds.IntersectsWith(a1.Bounds) && a1.Visible == true)
            {
                puncte -= 5;
                ap1 = false;
                a1.Visible = false;
                a1.Location = new Point(95, -10);
            }
            if (player.Bounds.IntersectsWith(a2.Bounds) && a2.Visible == true)
            {
                puncte -= 5;
                ap2 = false;
                a2.Visible = false;
                a2.Location = new Point(184, -10);
            }
            if (player.Bounds.IntersectsWith(a3.Bounds) && a3.Visible == true)
            {
                puncte -= 5;
                ap3 = false;
                a3.Visible = false;
                a3.Location = new Point(271, -10);
            }
            if (player.Bounds.IntersectsWith(a4.Bounds) && a4.Visible == true)
            {
                puncte -= 5;
                ap4 = false;
                a4.Visible = false;
                a4.Location = new Point(359, -10);
            }
            int r;
            r = random.Next(1, 20);
            int r1 = random1.Next(1, 8);
            bool ok = true;
            if (r == 1 && a1.Visible == false && (ap2 == false && ap3 == false && ap4 == false))
            {
                ap1 = true;
                a1.Visible = true;
                if (r1 == 1&&ok)
                {
                    a1.Width = 40;
                    a1.Height = 20;
                }
                else if (r1 == 3 &&ok)
                {
                    a1.Width = 50;
                    a1.Height = 50;
                    ok = false;
                }
                if (r1 == 7 &&ok)
                {
                    a1.Width = 70;
                    a1.Height = 50;
                    ok = false;
                }
                a1.Location = new Point(95, -10);
           
            }
            if (r == 5 && a2.Visible == false && (ap1 == false && ap3 == false && ap4 == false))
            {
                ap2 = true;
                a2.Visible = true;
                if (r1 == 1 && ok)
                {
                    a1.Width = 40;
                    a1.Height = 20;
                }
                else if (r1 == 3 && ok)
                {
                    a1.Width = 50;
                    a1.Height = 50;
                    ok = false;
                }
                if (r1 == 7 && ok)
                {
                    a1.Width = 70;
                    a1.Height = 50;
                    ok = false;
                }
                a2.Location = new Point(184, -10);
               
            }
            if (r == 10 && a3.Visible == false && (ap1 == false && ap2 == false && ap4 == false))
            {
                ap3 = true;
                a3.Visible = true;
                if (r1 == 1 && ok)
                {
                    a1.Width = 40;
                    a1.Height = 20;
                }
                else if (r1 == 3 && ok)
                {
                    a1.Width = 50;
                    a1.Height = 50;
                    ok = false;
                }
                if (r1 == 7 && ok)
                {
                    a1.Width = 70;
                    a1.Height = 50;
                    ok = false;
                }
                a3.Location = new Point(271, -10);
            }
            if (r == 15 && a4.Visible == false && (ap2 == false && ap3 == false && ap1 == false))
            {
                ap4 = true;
                a4.Visible = true;
                if (r1 == 1 && ok)
                {
                    a1.Width = 40;
                    a1.Height = 20;
                }
                else if (r1 == 3 && ok)
                {
                    a1.Width = 50;
                    a1.Height = 50;
                    ok = false;
                }
                if (r1 == 7 && ok)
                {
                    a1.Width = 70;
                    a1.Height = 50;
                    ok = false;
                }
                a4.Location = new Point(359, -10);
            }
            if (a1.Top >= 560)
            {
                ap1 = false;
                a1.Visible = false;
                if (r1 == 1 && ok)
                {
                    a1.Width = 40;
                    a1.Height = 20;
                }
                else if (r1 == 3 && ok)
                {
                    a1.Width = 50;
                    a1.Height = 50;
                    ok = false;
                }
                if (r1 == 7 && ok)
                {
                    a1.Width = 70;
                    a1.Height = 50;
                    ok = false;
                }
                a1.Location = new Point(95, -10);
            }
            if (a2.Top >= 560)
            {
                ap2 = false;
                a2.Visible = false;
                if (r1 == 1 && ok)
                {
                    a2.Width = 40;
                    a2.Height = 20;
                }
                else if (r1 == 3 && ok)
                {
                    a2.Width = 50;
                    a2.Height = 50;
                    ok = false;
                }
                if (r1 == 7 && ok)
                {
                    a2.Width = 70;
                    a2.Height = 50;
                    ok = false;
                }
                a2.Location = new Point(184, -10);
            }
            if (a3.Top >= 560)
            {
                ap3 = false;
                a3.Visible = false;
                if (r1 == 1 && ok)
                {
                    a3.Width = 40;
                    a3.Height = 20;
                }
                else if (r1 == 3 && ok)
                {
                    a3.Width = 50;
                    a3.Height = 50;
                    ok = false;
                }
                if (r1 == 7 && ok)
                {
                    a3.Width = 70;
                    a3.Height = 50;
                    ok = false;
                }
                a3.Location = new Point(271, -10);
            }
            if (a4.Top >= 560)
            {
                ap4 = false;
                a4.Visible = false;
                if (r1 == 1 && ok)
                {
                    a4.Width = 40;
                    a4.Height = 20;
                }
                else if (r1 == 3 && ok)
                {
                    a4.Width = 50;
                    a4.Height = 50;
                    ok = false;
                }
                if (r1 == 7 && ok)
                {
                    a4.Width = 70;
                    a4.Height = 50;
                    ok = false;
                }
                a4.Location = new Point(359, -10);
            }
            if (ap1 == true)
                a1.Top += speed;
            if (ap2 == true)
                a2.Top += speed;
            if (ap3 == true)
                a3.Top += speed;
            if (ap4 == true)
                a4.Top += speed;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbl_timp.Text = Convert.ToString(timp);
            timp++;
            speed +=2;
        }
    }
}
