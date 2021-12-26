using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChineseChessFinal
{
    public class 规则
    {

        public void Put(棋盘 chess,棋子 qiZi,int i, int j)
        {
           
            if (!chess.record.Contains(qiZi))
            {
                if ((qiZi.ChessR * 2) <= chess.StandardR && i > 0 && i <= chess.SizeX && j > 0 && j <= chess.SizeY)
                {
                    qiZi.LocationX = i;
                    qiZi.LocationY = j;
                    qiZi.PictureX = chess.StandardX + (chess.StandardR * (i - 1));
                    qiZi.PictureY = chess.StandardY + (chess.StandardR * (j - 1));

                    chess.Record(qiZi);
                }
            }
        }


        //开始函数：选子、移动循环。
        public void Start(棋盘 chess, PaintEventArgs e)
        {

            //循环开始
            while (!chess._win)
            {
                //选子
                棋子 qiZi = Choose(chess);
                //选中后输入移动位置
                if (qiZi != null)
                {
                    DrawCurrent(chess,e);

                    //吃子及移动判定
                    MoveRules(chess, qiZi);

                    DrawCurrent(chess,e);
                }
            }
        }

        //选择棋子函数
        public 棋子 Choose(棋盘 chess)
        {
            if (chess.Turn)
                Console.WriteLine("红方行棋。");
            else Console.WriteLine("黑方行棋。");
            
            Console.WriteLine("选棋子：");
          
            棋子 qiZi = chess.record.Find(chess.Search);

            if (qiZi != null)
            {
                qiZi._choose = true;
                Console.WriteLine("选中的棋子是" + qiZi.PaintColor + qiZi.Name);
            }
            else
            {
                Console.WriteLine("没有找到本方棋子。");
            }
            return qiZi;

        }


        //判定吃子和移动的函数，移动成功执行换方
        public void MoveRules(棋盘 chess, 棋子 qiZi)
        {
            if (qiZi != null)
            {
                Console.WriteLine("移动到：<<" + chess.PressX + ',' + chess.PressY + ">>。");
                棋子 qiZi1 = chess.record.Find(chess._Search);

                //有对方棋子，判定移动规则
                if (qiZi1 != null)
                {
                    chess.Eat = true;
                    //吃子时判断移动规则
                    if (qiZi.MoveRules(chess))//允许吃
                    {
                        //吃死将，本方胜，重新开始游戏
                        if (qiZi1.King)
                        {
                            Console.WriteLine(qiZi.PaintColor + "方胜！！");
                            chess._win = true;
                        }
                        chess.record.Remove(qiZi1);
                        Console.WriteLine("吃掉" + qiZi1.PaintColor + qiZi1.Name + "！");

                        chess.Eat = false;

                        //移动
                        Move(chess, qiZi);
                    }
                    else//不允许吃
                    {
                        Console.WriteLine("移动违规！！");
                        chess.Eat = false;

                    }

                }
                else//移动位置没有棋子
                {
                    //不吃子时判断移动规则
                    if (qiZi.MoveRules(chess))//允许走
                    {

                        //移动
                        Move(chess, qiZi);

                    }
                    else//不允许走
                    {
                        Console.WriteLine("移动违规！！");
                        chess.Eat = false;

                    }
                }
                qiZi._choose = false;
            }
        }

        //移动函数,移动后换方。
        public void Move(棋盘 chess, 棋子 qiZi)
        {
            //移动
            chess.Delete(qiZi);
            Put(chess, qiZi, chess.PressX, chess.PressY);
            Console.WriteLine(qiZi.PaintColor + qiZi.Name + "移动到:<<" + chess.PressX + ',' + chess.PressY + ">>。");
            //换方
            chess.Turn = !chess.Turn;

        }


       
        //画当前所有元素，以及选中状态。
        public void DrawCurrent(棋盘 chess, PaintEventArgs e)
        {
            chess.Draw(e);
            int i;
            for (i = 0; i < chess.record.Count; i++)
            {
                棋子 qiZi = chess.record[i];
                if (qiZi._choose)
                {
                    System.Console.WriteLine(qiZi.Choose + "的棋子是：");
                }
                qiZi.Draw(chess,e);
            }
        }

        //开局摆子
        public void DrawStart(棋盘 chess, PaintEventArgs e)
        {
            chess.record = new List<棋子> { };
            //摆棋子
            //红子
            棋子 cheR1 = new 车(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 cheR2 = new 车(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 maR1 = new 马(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 maR2 = new 马(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 paoR1 = new 炮(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 paoR2 = new 炮(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 xiangR1 = new 象(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 xiangR2 = new 象(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 shiR1 = new 士(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 shiR2 = new 士(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 bingR1 = new 兵(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 bingR2 = new 兵(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 bingR3 = new 兵(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 bingR4 = new 兵(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 bingR5 = new 兵(ChessColor.Red, chess.StandardR * 5 / 12);
            棋子 jiangR = new 将(ChessColor.Red, chess.StandardR * 5 / 12);

            Put(chess, cheR1, 1, 1);
            Put(chess, cheR2, 9, 1);
            Put(chess, maR1, 2, 1);
            Put(chess, maR2, 8, 1);
            Put(chess, xiangR1, 3, 1);
            Put(chess, xiangR2, 7, 1);
            Put(chess, shiR1, 4, 1);
            Put(chess, shiR2, 6, 1);
            Put(chess, jiangR, 5, 1);
            Put(chess, paoR1, 2, 3);
            Put(chess, paoR2, 8, 3);
            Put(chess, bingR1, 1, 4);
            Put(chess, bingR2, 3, 4);
            Put(chess, bingR3, 5, 4);
            Put(chess, bingR4, 7, 4);
            Put(chess, bingR5, 9, 4);

            //画棋子
            //黑子
            棋子 cheB1 = new 车(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 cheB2 = new 车(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 maB1 = new 马(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 maB2 = new 马(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 paoB1 = new 炮(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 paoB2 = new 炮(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 xiangB1 = new 象(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 xiangB2 = new 象(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 shiB1 = new 士(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 shiB2 = new 士(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 bingB1 = new 兵(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 bingB2 = new 兵(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 bingB3 = new 兵(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 bingB4 = new 兵(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 bingB5 = new 兵(ChessColor.Black, chess.StandardR * 5 / 12);
            棋子 jiangB = new 将(ChessColor.Black, chess.StandardR * 5 / 12);

            Put(chess, cheB1, 1, 10);
            Put(chess, cheB2, 9, 10);
            Put(chess, maB1, 2, 10);
            Put(chess, maB2, 8, 10);
            Put(chess, xiangB1, 3, 10);
            Put(chess, xiangB2, 7, 10);
            Put(chess, shiB1, 4, 10);
            Put(chess, shiB2, 6, 10);
            Put(chess, jiangB, 5, 10);
            Put(chess, paoB1, 2, 8);
            Put(chess, paoB2, 8, 8);
            Put(chess, bingB1, 1, 7);
            Put(chess, bingB2, 3, 7);
            Put(chess, bingB3, 5, 7);
            Put(chess, bingB4, 7, 7);
            Put(chess, bingB5, 9, 7);

            DrawCurrent(chess, e);
        }
    }
}
