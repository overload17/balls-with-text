using NUnit.Framework;
using System.Windows.Forms;
using System.Drawing;
using balls7;

namespace UTests
{
    [TestFixture]
    public class NUnitTest1
    {
        [Test]
        [TestCase(150, 50, 1, -1, 5, 155, 45)]
        [TestCase(100, 100, -3, 1, 10, 70, 110)]
        [TestCase(50, 50, -2, -2, 5, 40, 40)]
        [TestCase(50, 50, 5, 5, 10, 100, 100)]
        public void MoveTest(int x, int y, int dx, int dy, int ticks, int expX, int expY)
        {
            Panel pnl = new Panel();
            pnl.Width = pnl.Height = 500;
            Point p = new Point(x, y);
            Ball ball = new Ball(p, 10, Color.Black, dx, dy);
            pnl.Controls.Add(ball);
            for (int i = 0; i < ticks; i++)
            {
                Ball.moveAll(pnl.Controls);
            }
            Point exp = new Point(expX, expY);
            Point act = ball.Location;
            Assert.AreEqual(exp, act);
        }

        [Test]
        [TestCase(10, 240, 50, 2, 2, 10, 30, 240)]
        [TestCase(100, 10, 50, 2, -2, 10, 120, 10)]
        [TestCase(340, 100, 50, 2, 2, 10, 340, 120)]
        [TestCase(10, 10, 50, -2, 2, 10, 10, 30)]
        public void WallTest(int x, int y, int size, int dx, int dy, int ticks, int expX, int expY)
        {
            Panel pnl = new Panel
            {
                Width = 400,
                Height = 300
            };
            Point p = new Point(x, y);
            Ball ball = new Ball(p, size, Color.Black, dx, dy);
            pnl.Controls.Add(ball);
            for (int i = 0; i < ticks; i++)
            {
                Ball.moveAll(pnl.Controls);
            }
            Point exp = new Point(expX, expY);
            Point act = ball.Location;
            Assert.AreEqual(exp, act);
        }

        [Test]
        public void CollideTest()
        {
            Panel pnl = new Panel();
            pnl.Width = pnl.Height = 400;
            Ball ball1 = new Ball(new Point(10, pnl.Height / 2 - 50), 100, Color.Black, 2, 0);
            Ball ball2 = new Ball(new Point(pnl.Width - 110, pnl.Height / 2 - 50), 100, Color.Red, -2, 0);
            pnl.Controls.Add(ball1);
            pnl.Controls.Add(ball2);
        }
    }
}