using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChessFinal
{
    public class 将 : 棋子
    {

       public 将(ChessColor color,int chessR)
       {
           _color = color;
           _chessR = chessR;
           _king = true;
       }

       public bool InRange(棋盘 chess)
       {
           if (BoolColor)
           {
               if (chess.PressX >= 4 && chess.PressX <= 6 && chess.PressY >= 1 && chess.PressY <= 3)
                   return true;
               return false;
           }
           else
           {
               if (chess.PressX >= 4 && chess.PressX <= 6 && chess.PressY >= 8 && chess.PressY <= 10)
                   return true;
               return false;
           }
       }

        //判断对脸函数
       public bool Face(棋盘 chess)
       {
           chess._currentX = chess.PressX;
           chess._currentY = chess.PressY;
           if (BoolColor)
           {
               for (chess._currentY = chess.PressY + 1; chess._currentY <= 10; chess._currentY++)
               {
                   棋子 qiZi = chess.record.Find(chess.SearchAll);
                   if (qiZi != null)
                   {
                       if (qiZi.King) return true;
                       else return false; 
                   }
               }
               return false;
           }
           else
           {
               for (chess._currentY = chess.PressY - 1; chess._currentY >= 1; chess._currentY--)
               {
                   棋子 qiZi = chess.record.Find(chess.SearchAll);
                   if (qiZi != null)
                   {
                       if (qiZi.King)
                       {
                           Console.WriteLine("对脸！！");
                           return true;
                       }
                       else return false;
                   }
               }
               return false;
           }
       }
       
        //移动规则将
       public override bool MoveRules(棋盘 chess)
       {
           //是否在范围内
           if (InRange(chess))
           {
               //是否对脸
               if (!Face(chess))
               {
                   if (chess.PressX == LocationX && (chess.PressY == (LocationY - 1) || chess.PressY == (LocationY + 1)))
                       return true;
                   else if (chess.PressY == LocationY && (chess.PressX == (LocationX - 1) || chess.PressX == (LocationX + 1)))
                       return true;
                   else
                       return false;
               }

           }
           else Console.WriteLine("超出范围！！");
           return false;
       }

        public override string Name
        {
            get 
            {
                if (this._Color == ChessColor.Red) return "帅";
                else return "将";
            }
        }
    }
}
