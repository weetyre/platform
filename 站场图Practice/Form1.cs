using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 站场图Practice
{
    public partial class Field : Form
    {
        public int drt;
        Panel front = new Panel();
        Panel back = new Panel();      
        DateTime dt = new DateTime(2018, 9, 20, 8, 20, 00);
        Timer trainTimer = new Timer();
        Point[] snake = new Point[10];
        int second = 0;
        Point Xred = new Point(37, 240);
        Point XGreen = new Point(42, 240);
        Point X3red = new Point(607, 190);
        Point X3Green = new Point(612, 190);
        Point XFred = new Point(42, 300);
        Point XFGreen = new Point(47, 300);
        Point X1red = new Point(747, 240);
        Point X1Green = new Point(752, 240);
        Point X2red = new Point(747, 290);
        Point X2Green = new Point(752, 290);
        Point X4red = new Point(657, 340);
        Point X4Green = new Point(662, 340);
        Point X6red = new Point(597, 390);
        Point X6Green = new Point(602, 390);
        Point X8red = new Point(552, 440);
        Point X8Green = new Point(557, 440);
        Point X5red = new Point(607, 140);
        Point X5Green = new Point(612, 140);

        Point S1red = new Point(233, 250);
        Point S1Green = new Point(226, 250);
        Point S2red = new Point(233, 300);
        Point S2Green = new Point(226, 300);
        Point S3red = new Point(384, 200);
        Point S3Green = new Point(377, 200);
        Point S4red = new Point(313, 355);
        Point S4Green = new Point(306, 355);
        Point S6red = new Point(393, 405);
        Point S6Green = new Point(386, 405);
        Point S8red = new Point(413, 455);
        Point S8Green = new Point(406, 455);
        Point S5red = new Point(384, 150);
        Point S5Green = new Point(377, 150);
        Point SFred = new Point(980, 240);
        Point SFGreen = new Point(973, 240);
        Point Sred = new Point(980, 303);
        Point SGreen = new Point(973, 303);

        public Field()
        {
            this.Size = new Size(1300, 750);
            this.BackColor = Color.Black;
            back.Size= new Size(1300, 750);
            back.BackColor = Color.Black;
            front.Size = new Size(1300, 750);
            front.BackColor = Color.Transparent;
            this.Controls.Add(back);
            this.back.SendToBack();
            this.front.BringToFront();
            back.Visible = true;
            front.Visible = true;
            this.Show();
            DrawLine();
            trainTimer.Interval = 300;
            this.trainTimer.Tick += new EventHandler(train_Tick);
            Font LineId = new Font("宋体", 8);
            Graphics g = back.CreateGraphics();
            snake[0].X = 0;
            snake[0].Y = 250;
            trainTimer.Start();
        }
        public void train_Tick(object sender, EventArgs e)
        {
            Graphics g = back.CreateGraphics();
            g.Clear(Color.Transparent);
            Point temp = snake[0];           
            DrawLine();
            DrawRedLight(S1red);
            DrawRedLight(S3red);
            DrawRedLight(S5red);
            DrawRedLight(X1red);
            DrawRedLight(X5red);
            DrawRedLight(X3red);
            DrawGreenLight(XGreen);

            if (snake[0].X < 195)
            {
                snake[0].X = temp.X + 15;
            }
            if (snake[0].X == 195)
            {
                snake[0].Y = temp.Y - 25;
                snake[0].X = temp.X + 15;
            }
            if ((snake[0].X >195)&&(snake[0].X < 555) && (snake[0].X != 555)) 
            {
                snake[0].X = temp.X + 15;
            }
            if ((snake[0].X == 555) && (second < 10))
            {
                second += 1;
            }
            if ((snake[0].X == 555) && (second == 10))
            {
                snake[0].X = temp.X + 15;
                TurnOff(X3red);
               
            }
            if ((snake[0].X > 555) && (snake[0].X < 750))
            {
                snake[0].X = temp.X + 15;
                TurnOff(X3red);
                DrawGreenLight(X3Green);
            }                     
            if (snake[0].X == 750)
            {
                snake[0].Y = temp.Y+25;
                snake[0].X = temp.X + 15;
            }
            if (snake[0].X>750)
            {
                snake[0].X = temp.X + 15;
                TurnOff(X3red);
                DrawGreenLight(X3Green);
            }


            DrawTrain(snake[0].X, snake[0].Y);

        }
        public void DrawTrain(int x, int y)
        {
            Graphics g = back.CreateGraphics();
            g.FillEllipse(Brushes.Red, x, y, 50, 5);

        }
        public void DrawLine()
        {
            Graphics g = back.CreateGraphics();
            Font LineId = new Font("宋体", 8);            
            g.DrawString(dt.ToString(), LineId, Brushes.White, (float)0, (float)0);

            //股道
            g.DrawLine(new Pen(Color.White), 350, 150, 650, 150);
            g.DrawLine(new Pen(Color.White), 200, 200, 1100, 200);
            g.DrawLine(new Pen(Color.White), 30, 250, 1240, 250);
            g.DrawLine(new Pen(Color.White), 30, 300, 1240, 300);
            g.DrawLine(new Pen(Color.White), 200, 350, 1000, 350);
            g.DrawLine(new Pen(Color.White), 330, 400, 650, 400);
            g.DrawLine(new Pen(Color.White), 200, 450, 750, 450);
            //车挡
            g.DrawLine(new Pen(Color.White), 200, 195, 200, 205);
            g.DrawLine(new Pen(Color.White), 195, 195, 200, 195);
            g.DrawLine(new Pen(Color.White), 195, 205, 200, 205);

            g.DrawLine(new Pen(Color.White), 200, 345, 200, 355);
            g.DrawLine(new Pen(Color.White), 195, 345, 200, 345);
            g.DrawLine(new Pen(Color.White), 195, 355, 200, 355);

            g.DrawLine(new Pen(Color.White), 200, 445, 200, 455);
            g.DrawLine(new Pen(Color.White), 195, 445, 200, 445);
            g.DrawLine(new Pen(Color.White), 195, 455, 200, 455);

            g.DrawLine(new Pen(Color.White), 1100, 195, 1100, 205);
            g.DrawLine(new Pen(Color.White), 1100, 195, 1105, 195);
            g.DrawLine(new Pen(Color.White), 1100, 205, 1105, 205);

            g.DrawLine(new Pen(Color.White), 1000, 345, 1000, 355);
            g.DrawLine(new Pen(Color.White), 1000, 345, 1005, 345);
            g.DrawLine(new Pen(Color.White), 1000, 355, 1005, 355);

            //道岔
            g.DrawLine(new Pen(Color.White), 60, 250, 100, 300);
            g.DrawLine(new Pen(Color.White), 120, 300, 170, 250);
            g.DrawLine(new Pen(Color.White), 200, 250, 250, 200);
            g.DrawLine(new Pen(Color.White), 300, 200, 350, 150);
            g.DrawLine(new Pen(Color.White), 650, 150, 700, 200);
            g.DrawLine(new Pen(Color.White), 200, 300, 250, 350);
            g.DrawLine(new Pen(Color.White), 280, 350, 330, 400);
            g.DrawLine(new Pen(Color.White), 650, 400, 700, 350);
            g.DrawLine(new Pen(Color.White), 350, 400, 400, 450);
            g.DrawLine(new Pen(Color.White), 590, 450, 640, 400);
            g.DrawLine(new Pen(Color.White), 650, 150, 700, 200);
            g.DrawLine(new Pen(Color.White), 820, 250, 870, 300);
            g.DrawLine(new Pen(Color.White), 950, 250, 900, 300);
            g.DrawLine(new Pen(Color.White), 750, 200, 800, 250);
            g.DrawLine(new Pen(Color.White), 750, 350, 800, 300);
            g.DrawLine(new Pen(Color.White), 750, 450, 850, 350);
            g.DrawLine(new Pen(Color.White), 675, 175, 800, 175);
            g.DrawLine(new Pen(Color.White), 800, 175, 825, 200);
            //股道标号
            g.DrawString("5道",LineId, Brushes.White,(float)470,(float)155);
            g.DrawString("3道", LineId, Brushes.White, (float)470, (float)205);
            g.DrawString("Ⅰ道", LineId, Brushes.White, (float)470, (float)255);
            g.DrawString("Ⅱ道", LineId, Brushes.White, (float)470, (float)305);
            g.DrawString("4道", LineId, Brushes.White, (float)470, (float)355);
            g.DrawString("6道", LineId, Brushes.White, (float)470, (float)405);
            g.DrawString("8道", LineId, Brushes.White, (float)470, (float)455);
            //道岔编号
            g.DrawString("1", LineId, Brushes.White, (float)50, (float)253);
            g.DrawString("3", LineId, Brushes.White, (float)97, (float)303);
            g.DrawString("5", LineId, Brushes.White, (float)117, (float)303);
            g.DrawString("7", LineId, Brushes.White, (float)135, (float)253);
            g.DrawString("9", LineId, Brushes.White, (float)195, (float)237);
            g.DrawString("11", LineId, Brushes.White, (float)233, (float)190);
            g.DrawString("13", LineId, Brushes.White, (float)193, (float)305);
            g.DrawString("15", LineId, Brushes.White, (float)243, (float)355);
            g.DrawString("17", LineId, Brushes.White, (float)268, (float)355);
            g.DrawString("19", LineId, Brushes.White, (float)338, (float)405);
            g.DrawString("21", LineId, Brushes.White, (float)388, (float)455);
            g.DrawString("23", LineId, Brushes.White, (float)289, (float)190);
            g.DrawString("2", LineId, Brushes.White, (float)935, (float)240);
            g.DrawString("4", LineId, Brushes.White, (float)895, (float)300);
            g.DrawString("6", LineId, Brushes.White, (float)860, (float)300);
            g.DrawString("8", LineId, Brushes.White, (float)820, (float)240);
            g.DrawString("10", LineId, Brushes.White, (float)785, (float)255);
            g.DrawString("12", LineId, Brushes.White, (float)745, (float)190);
            g.DrawString("14", LineId, Brushes.White, (float)785, (float)285);
            g.DrawString("16", LineId, Brushes.White, (float)745, (float)355);
            g.DrawString("18", LineId, Brushes.White, (float)695, (float)340);
            g.DrawString("20", LineId, Brushes.White, (float)640, (float)385);
            g.DrawString("22", LineId, Brushes.White, (float)585, (float)435);
            g.DrawString("24", LineId, Brushes.White, (float)835, (float)340);
            g.DrawString("26", LineId, Brushes.White, (float)820, (float)190);
            g.DrawString("28", LineId, Brushes.White, (float)695, (float)190);
            g.DrawString("30", LineId, Brushes.White, (float)670, (float)160);

            g.DrawString("郑西高铁上行", LineId, Brushes.Orange, (float)100, (float)370);
            g.DrawLine(new Pen(Color.Orange), 100, 360, 170, 360);
            g.DrawLine(new Pen(Color.Orange), 100, 360, 110, 370);

            g.DrawString("郑西高铁下行", LineId, Brushes.Orange, (float)1150, (float)210);
            g.DrawLine(new Pen(Color.Orange), 1150, 230, 1220, 230);
            g.DrawLine(new Pen(Color.Orange), 1220, 230, 1210, 220);
            //信号灯及其编号
            g.DrawString("X", LineId, Brushes.White, (float)30, (float)240);
            

            g.DrawString("XF", LineId, Brushes.White, (float)30, (float)300);
            

            g.DrawString("X1", LineId, Brushes.White, (float)735, (float)240);
           
            g.DrawString("X2", LineId, Brushes.White, (float)735, (float)290);
           

            g.DrawString("X3", LineId, Brushes.White, (float)595, (float)190);
            

            g.DrawString("X4", LineId, Brushes.White, (float)645, (float)340);
            

            g.DrawString("X6", LineId, Brushes.White, (float)585, (float)390);
           

            g.DrawString("X8", LineId, Brushes.White, (float)540, (float)440);
            

            g.DrawString("X5", LineId, Brushes.White, (float)595, (float)140);
            

            g.DrawString("S1", LineId, Brushes.White, (float)238, (float)250);
            
            
            g.DrawString("S2", LineId, Brushes.White, (float)238, (float)300);
            

            g.DrawString("S3", LineId, Brushes.White, (float)389, (float)200);
            

            g.DrawString("S4", LineId, Brushes.White, (float)318, (float)355);
            
            g.DrawString("S6", LineId, Brushes.White, (float)398, (float)405);
           

            g.DrawString("S8", LineId, Brushes.White, (float)418, (float)455);
            
            g.DrawString("S5", LineId, Brushes.White, (float)389, (float)150);
            

            g.DrawString("SF", LineId, Brushes.White, (float)985, (float)240);
           

            g.DrawString("S", LineId, Brushes.White, (float)985, (float)303);
      
        }
        public void DrawRedLight(Point point)
        {
        Graphics g = back.CreateGraphics();
        g.FillEllipse(Brushes.Red, point.X,point.Y, 5, 5);
        }
       public void DrawGreenLight(Point point)
       {
        Graphics g = back.CreateGraphics();
        g.FillEllipse(Brushes.Green, point.X,point.Y, 5, 5);
       }
       public void TurnOff(Point point)
       {
        Graphics g = back.CreateGraphics();
        g.FillEllipse(Brushes.Black, point.X, point.Y, 5, 5);
       }
       
    }
}
