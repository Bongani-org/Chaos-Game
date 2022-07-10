/* Bongani Lefaso Mabizela
 * 2016074458
 * CSIS 1624 Practical Assignment 1*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _2016074458_Practical_Assignment_1
{
    class Program
    {
        #region Properties
        static Graphics g;
        static Panel pnlChaos;
        static Button btnStart;
        static NumericUpDown nudIterate;
        private static Point point1;
        private static Point point2;
        private static Point point3;
        private static Point[] points;
        #endregion Properties

        static void Main(string[] args)
        {
            Form frmChaos = new Form();
            frmChaos.Text = "CHAOS GAME";
            frmChaos.Width = 520;
            frmChaos.Height = 500;
            frmChaos.MinimizeBox = frmChaos.MaximizeBox = false;
            frmChaos.StartPosition = FormStartPosition.CenterScreen;

            pnlChaos = new Panel();
            pnlChaos.Left = pnlChaos.Top = 5;
            pnlChaos.Width = 490;
            pnlChaos.Height = 430;
            pnlChaos.BackColor = Color.White;
            frmChaos.Controls.Add(pnlChaos);

            btnStart = new Button();
            btnStart.Text = "Start";
            btnStart.Left = pnlChaos.Left;
            btnStart.Top = pnlChaos.Bottom;
            btnStart.Click += BtnStart_Click;
            frmChaos.Controls.Add(btnStart);

            Label lblIterate = new Label();
            lblIterate.Text = "Iterations";
            lblIterate.Top = pnlChaos.Bottom + 2;
            lblIterate.Left = btnStart.Right + 240;
            lblIterate.AutoSize = true;
            frmChaos.Controls.Add(lblIterate);

            nudIterate = new NumericUpDown();
            nudIterate.Left = lblIterate.Right;
            nudIterate.Top = pnlChaos.Bottom;
            nudIterate.Minimum = 1000; nudIterate.Maximum = 100000;
            nudIterate.Increment = 1000;
            nudIterate.AutoSize = true;
            frmChaos.Controls.Add(nudIterate);

            Application.Run(frmChaos);
        }

        private static void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            g = pnlChaos.CreateGraphics();
            g.Clear(Color.White);
            point1 = new Point(pnlChaos.Width / 2 - 5, 10);
            point2 = new Point(10, pnlChaos.Height - 20);
            point3 = new Point(pnlChaos.Width - 20, pnlChaos.Height - 20);
            points = new Point[] { point1, point2, point3 };
            g.FillEllipse(new SolidBrush(Color.Red), points[0].X, points[0].Y, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Red), points[1].X, points[1].Y, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Red), points[2].X, points[2].Y, 10, 10);
            StartSimulation();
        }

        private static void StartSimulation()
        {
            int i = (int)nudIterate.Value;
            Iterations(i);
            btnStart.Enabled = true;
        }

        private static void Iterations(int n)
        {

            Random r = new Random();
            int x = r.Next(0, pnlChaos.Width - 20);
            int y = r.Next(0, pnlChaos.Height - 20);
            Point point = new Point(x, y);

            for (int i = 0; i < n; i++)
            {
                int rand = r.Next(3);
                g.FillEllipse(new SolidBrush(Color.Black), point.X, point.Y, 2, 2);
                point.X = (points[rand].X + point.X) / 2;
                point.Y = (points[rand].Y + point.Y) / 2;
            }
        }

    }
    #region References
    //https://github.com/LeeHolmes/Sierpinski/blob/master/Sierpinski.cs
    //http://www.blackwasp.co.uk/sierpinskitriangle_2.aspx
    //https://en.wikipedia.org/wiki/Sierpi%C5%84ski_triangle#Chaos_game
    #endregion References
}
