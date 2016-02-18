using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace balls7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 20;
            timer1.Start();
        }

        private void pnl_MouseUp(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            pnl.Controls.Add(new Ball(e.Location, 40, Color.Black, rnd.Next(-5, 5), rnd.Next(-5, 5)));

            //pnl.Controls.Add(new Ball(new Point(10, 10), 100, Color.Red, 2, 2));
            //pnl.Controls.Add(new Ball(new Point(310, 310), 100, Color.Black, -2, -2));

            //pnl.Controls.Add(new Ball(new Point(310, 10), 100, Color.Red, -2, 2));
            //pnl.Controls.Add(new Ball(new Point(10, 310), 100, Color.Black, 2, -2));

            //pnl.Controls.Add(new Ball(new Point(200, 10), 100, Color.Red, 0, 2));
            //pnl.Controls.Add(new Ball(new Point(200, 310), 100, Color.Black, 0, -2));

            //pnl.Controls.Add(new Ball(new Point(10, 200), 100, Color.Red, 2, 0));
            //pnl.Controls.Add(new Ball(new Point(310, 200), 100, Color.Black, -2, 0));

            //pnl.Controls.Add(new Ball(new Point(10, 10), 50, Color.Black, -2, 2));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ball.moveAll(pnl.Controls);
        }
    }
}
