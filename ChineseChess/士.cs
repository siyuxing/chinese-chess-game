using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChessFinal
{
    public class 士 : 棋子
    {
       public 士(ChessColor color,int chessR)
       {
           _color = color;
           _chessR = chessR;
           _king = false;
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

       //移动规则士
       public override bool MoveRules(棋盘 chess)
       {
           //是否在范围内
           if (InRange(chess))
           {
               if ((chess.PressX == (LocationX - 1) || chess.PressX == (LocationX + 1)) 
                   && (chess.PressY == (LocationY - 1) || chess.PressY == (LocationY + 1)))
                   return true;
               else
                   return false;
           }
           else Console.WriteLine("超出范围！！");
           return false;
       }

        public override string Name
        {
            get
            {
                if (this._Color == ChessColor.Red) return "士";
                else return "仕";
            }
        }
    }
}
