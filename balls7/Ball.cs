using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace balls7
{
    public class Ball : PictureBox
    {
        public int dx;
        public int dy;
        public int nextX;
        public int nextY;
        Color c;

        public Ball(Point p, int size, Color c, int dx, int dy)
        {
            this.dx = dx;
            this.dy = dy;
            this.c = c;
            Location = p;
            Height = Width = size;
            nextX = Location.X + dx;
            nextY = Location.Y + dy;
            setRegion();
        }

        public void movePos()
        {
            Point p = Location;
            p.X = nextX;
            p.Y = nextY;
            nextX += dx;
            nextY += dy;
            Location = p;
        }

        public void testWall()
        {
            if (Location.X <= 0)
            {
                dx = Math.Abs(dx);
                nextX += dx;
            }
            else if (Location.X + Width >= Parent.Width)
            {
                dx = -Math.Abs(dx);
                nextX += dx;
            }
            else if (Location.Y <= 0)
            {
                dy = Math.Abs(dy);
                nextY += dy;
            }
            else if (Location.Y + Height >= Parent.Height)
            {
                dy = -Math.Abs(dy);
                nextY += dy;
            }
        }

        private void setRegion()
        {
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddEllipse(0, 0, Width, Height);
            Region = new Region(gPath);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.FillEllipse(new SolidBrush(c), 0, 0, Width, Height);
        }

        public static bool hitTest(Ball b1, Ball b2)
        {
            var d = Math.Sqrt(Math.Pow(b1.nextX - b2.nextX, 2) + Math.Pow(b1.nextY - b2.nextY, 2));
            if (d < b1.Width / 2 + b2.Width / 2)
            {
                return true;
            }
            return false;
        }

        public static void collide(Ball b1, Ball b2)
        {
            b1.dx = -b1.dx;
            b1.dy = -b1.dy;
            b1.nextX = b1.Location.X + b1.dx;
            b1.nextY = b1.Location.Y + b1.dy;
            b2.dx = -b2.dx;
            b2.dy = -b2.dy;
            b2.nextX = b2.Location.X + b2.dx;
            b2.nextY = b2.Location.Y + b2.dy;
        }

        public static void moveAll(ControlCollection balls)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                Ball b1 = (balls[i] as Ball);
                for (int j = 0; j < balls.Count; j++)
                {
                    Ball b2 = (balls[j] as Ball);
                    if (i != j && hitTest(b1, b2))
                    {
                        collide(b1, b2);
                    }
                }
                b1.movePos();
                b1.testWall();
            }
        }
    }
}

