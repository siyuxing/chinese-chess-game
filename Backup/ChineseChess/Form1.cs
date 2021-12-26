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
    public partial class Form1 : Form
    {
        棋盘 chess = new 棋盘(210, 29, 60);
        规则 rules = new 规则();
        棋子 qiZi = null;
        bool _start = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (!_start)
            {
                
                rules.DrawStart(chess, e);
                _start = true;
            }
            else
            {
                //选子
                棋子 qiZi1 = rules.Choose(chess);

                if (qiZi1 != null)
                {
                    if (qiZi != null) qiZi._choose = false;
                    qiZi1._choose = true;
                    qiZi = qiZi1;
                    rules.DrawCurrent(chess, e);

                }
                else
                {

                    //吃子及移动判定
                    rules.MoveRules(chess, qiZi);

                    rules.DrawCurrent(chess, e);
                    qiZi = null;
                    if (chess._win)
                    {
                        //参数归零
                        chess.Turn = true;
                        _start = false;
                        chess._win = false;
                    }
                }

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(chess.Press(e.X,e.Y)) pictureBox1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
