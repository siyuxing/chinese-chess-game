using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChessFinal
{
    public class 象 : 棋子
    {

       public 象(ChessColor color,int chessR)
       {
           _color = color;
           _chessR = chessR;
           _king = false;
       }

       public bool InRange(棋盘 chess)
       {
           if (BoolColor)
           {
               if (chess.PressY < 6)
                   return true;
               return false;
           }
           else
           {
               if (chess.PressY > 5)
                   return true;
               return false;
           }
       }

        //判断别腿函数
       public bool Block(棋盘 chess)
       {
           chess._currentX = (chess.PressX + LocationX) / 2;
           chess._currentY = (chess.PressY + LocationY) / 2;
           棋子 qiZi = chess.record.Find(chess.SearchAll);
           if (qiZi != null)
           {
               Console.WriteLine("别腿！！");
               return true; 

           }
           else return false;
       }

       //移动规则象
       public override bool MoveRules(棋盘 chess)
       {
           //是否在范围内
           if (InRange(chess))
           {
               if ((chess.PressX == (LocationX - 2) || chess.PressX == (LocationX + 2))
                   && (chess.PressY == (LocationY - 2) || chess.PressY == (LocationY + 2)))
               {
                   //判断是否别腿
                   if (!Block(chess)) return true;
               }
               else return false;
           }
           else Console.WriteLine("超出范围！！");
           return false;
       }


        public override string Name
        {
            get
            {
                if (this._Color == ChessColor.Red) return "相";
                else return "象";
            }
        }
    }
}
