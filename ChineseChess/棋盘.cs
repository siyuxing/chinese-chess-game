using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChineseChessFinal
{
    public class 棋盘
    {
        int _standardX, _standardY, _standardR;
        int _pressX, _pressY;
        public List<棋子> record;
        public bool _turn = true, _eat = false, _win = false;
        public int _currentX, _currentY;//搜索行列坐标函数

        //轮换属性
        public bool Turn
        {
            set { _turn = value; }
            get { return _turn; }
        }
        //吃子属性
        public bool Eat
        {
            set { _eat = value; }
            get { return _eat; }
        }

        public 棋盘(int standardX, int standardY, int standardR )
        {
            _standardX = standardX;
            _standardY = standardY;
            _standardR = standardR;
        }

        public string Name
        {
            get { return "象棋棋盘"; }
        }


        //规格
        public int StandardR//间距
        {
            set { _standardR = value; }
            get { return _standardR; }
        }
        public int StandardX//初始X
        {
            set { _standardX = value; }
            get { return _standardX; }
        }
        public int StandardY//初始Y
        {
            set { _standardY = value; }
            get { return _standardY; }
        }
        public int SizeX//行数
        {
            get { return 9; }
        }
        public int SizeY//行数
        {
            get { return 10; }
        }
        public int PressX//Click行
        {
            set { _pressX = value; }
            get { return _pressX; }
        }
        public int PressY//Click列
        {
            set { _pressY = value; }
            get { return _pressY; }
        }

        //记录函数
        public void Record(棋子 qiZi)
        {
            System.Console.WriteLine("在棋盘的<<" + qiZi.LocationX + ',' + qiZi.LocationY + ">>上放了棋子。");
            record.Add(qiZi);
        }

        //删除函数
        public void Delete(棋子 qiZi)
        {
            System.Console.WriteLine("在棋盘的<<" + qiZi.LocationX + ',' + qiZi.LocationY + ">>上的棋子已经删除。");
            record.Remove(qiZi);
        }

        //记录像素函数。
        public bool Press(int x, int y)
        {
            double m = (double)x;
            double n = (double)y;
            PressX = (int)((m - StandardX) / StandardR + 1.5);
            PressY = (int)((n - StandardY) / StandardR + 1.5);
            if (PressX > 0 && PressX <= SizeX && PressY > 0 && PressY <= SizeY)
            {
                Console.WriteLine("行列值为：<<" + PressX + ',' + PressY + ">>。");
                return true;
            }
            else
            {
                Console.WriteLine("行列值<<" + PressX + ',' + PressY + ">>无效！");
                return false;
            }
        }

        //Find委托方法1，搜索XY位置本方的棋子
        public bool Search(棋子 qiZi)
        {
            if (qiZi.LocationX == PressX && qiZi.LocationY == PressY && Turn == qiZi.BoolColor)
                return true;
            return false;
        }

        //Find委托方法2，搜索XY位置对方的棋子
        public bool _Search(棋子 qiZi)
        {
            if (qiZi.LocationX == PressX && qiZi.LocationY == PressY && Turn != qiZi.BoolColor)
                return true;
            return false;
        }
        //Find委托方法3，搜索X行从qiZi.LocationX到PressX，Y固定
        public bool SearchAll(棋子 qiZi)
        {
            if (qiZi.LocationX == _currentX && qiZi.LocationY == _currentY)
                return true;
            return false;
        }

        public 棋子 Find()
        {
            棋子 qiZi = record.Find(Search);
            return qiZi;
        }
        public void Draw(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 2);

            int i, j;
            int x, y;
            //画格子
            //画横线
            for (i = 0; i < SizeY; i++)
            {
                g.DrawLine(p, StandardX, StandardY + (StandardR * i), StandardX + StandardR * (SizeX - 1), StandardY + (StandardR * i));
            }
            //画竖线
            for (i = 1; i < SizeX; i++)
            {
                g.DrawLine(p, StandardX  + (StandardR  * i), StandardY , StandardX + (StandardR * i), StandardY + StandardR * 4 );
                g.DrawLine(p, StandardX + (StandardR * i), StandardY + StandardR * 5, StandardX + (StandardR * i), StandardY + StandardR * 9);
            }
            g.DrawLine(p, StandardX, StandardY, StandardX, StandardY + StandardR * (SizeY - 1));
            g.DrawLine(p, StandardX + StandardR * (SizeX - 1), StandardY, StandardX + StandardR * (SizeX - 1), StandardY + StandardR * (SizeY - 1));
            //斜线
            g.DrawLine(p, StandardX + StandardR * 3, StandardY, StandardX + StandardR * 5, StandardY + StandardR * 2);
            g.DrawLine(p, StandardX + StandardR * 3, StandardY + StandardR * 2, StandardX + StandardR * 5, StandardY);
            g.DrawLine(p, StandardX + StandardR * 3, StandardY + StandardR * 7, StandardX + StandardR * 5, StandardY + StandardR * 9);
            g.DrawLine(p, StandardX + StandardR * 3, StandardY + StandardR * 9, StandardX + StandardR * 5, StandardY + StandardR * 7);

            //画十字
            int l = StandardR / 12;
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    x = StandardX + (StandardR * i * 2); y = StandardY + (StandardR * (j+1) * 3);
                    if (x == StandardX)
                    {
                        g.DrawLine(p, x + l, y - 2 * l, x + l, y - l);
                        g.DrawLine(p, x + l, y + l, x + l, y + 2*l);
                        g.DrawLine(p, x + l, y - l, x + 2*l, y - l);
                        g.DrawLine(p, x + l, y + l, x + 2*l, y + l);
                    }
                    else if (x == StandardX + (StandardR * 8))
                    {
                        g.DrawLine(p, x - l, y - 2*l, x - l, y - l);
                        g.DrawLine(p, x - l, y + l, x - l, y + 2 * l);
                        g.DrawLine(p, x - 2 * l, y - l, x - l, y - l);
                        g.DrawLine(p, x - 2 * l, y + l, x - l, y + l);
                    }
                    else
                    {
                        g.DrawLine(p, x + l, y - 2 * l, x + l, y - l);
                        g.DrawLine(p, x + l, y + l, x + l, y + 2 * l);
                        g.DrawLine(p, x + l, y - l, x + 2 * l, y - l);
                        g.DrawLine(p, x + l, y + l, x + 2 * l, y + l);
                        g.DrawLine(p, x - l, y - 2 * l, x - l, y - l);
                        g.DrawLine(p, x - l, y + l, x - l, y + 2 * l);
                        g.DrawLine(p, x - 2 * l, y - l, x - l, y - l);
                        g.DrawLine(p, x - 2 * l, y + l, x - l, y + l);

                    }

                }

            }
            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    x = StandardX + StandardR + (StandardR  * i * 6); y = StandardY + StandardR * 2 + (StandardR * j *5);
                        g.DrawLine(p, x + l, y - 2 * l, x + l, y - l);
                        g.DrawLine(p, x + l, y + l, x + l, y + 2 * l);
                        g.DrawLine(p, x + l, y - l, x + 2 * l, y - l);
                        g.DrawLine(p, x + l, y + l, x + 2 * l, y + l);
                        g.DrawLine(p, x - l, y - 2 * l, x - l, y - l);
                        g.DrawLine(p, x - l, y + l, x - l, y + 2 * l);
                        g.DrawLine(p, x - 2 * l, y - l, x - l, y - l);
                        g.DrawLine(p, x - 2 * l, y + l, x - l, y + l);
                }
            }

            //楚河汉界
            SolidBrush myBrush = new SolidBrush(Color.Black);
            Font myFont = new Font("楷体", StandardR/2);
            g.DrawString("漢 界", myFont, myBrush, new PointF(StandardX + StandardR ,StandardY + (int)(StandardR * 4.15)));
            g.DrawString("楚 河", myFont, myBrush, new PointF(StandardX + StandardR * 5, StandardY + (int)(StandardR * 4.15)));
 
            //画标识
            Pen q = new Pen(Color.Silver , 3);
            Font signFont = new Font("宋体", StandardR / 3);
            SolidBrush signBrush = new SolidBrush(Color.Red);
            Rectangle rect = new Rectangle(30, 90, StandardR * 22 / 10, StandardR / 2);
            /*实心框架画法
            SolidBrush q = new SolidBrush(Color.Silver);
            g.FillRectangle(q, rect);
             */
            
            g.DrawRectangle(q, rect);
            if (_win)
            {
                if (Turn) g.DrawString("黑方胜！！", signFont, signBrush, new PointF(30, 91));
                else g.DrawString("红方胜！！", signFont, signBrush, new PointF(30, 91));
            }
            else
            {
                if (Turn) g.DrawString("红方行棋！", signFont, signBrush, new PointF(30, 91));
                else g.DrawString("黑方行棋！", signFont, signBrush, new PointF(30, 91));
            }
        }
    
    }
}
