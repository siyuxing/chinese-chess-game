using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChessFinal
{
    public class 兵 : 棋子
    {

       public 兵(ChessColor color, int chessR)
       {
           _color = color;
           _chessR = chessR;
           _king = false;
       }

       public bool Pass(棋盘 chess)
       {
           if (BoolColor)
           {
               if ( chess.PressY > 5 )
                   return true;
               return false;
           }
           else
           {
               if ( chess.PressY < 6 )
                   return true;
               return false;
           }
       }

       //移动规则兵
       public override bool MoveRules(棋盘 chess)
       {
           //是否过河
           if (Pass(chess))
           {
               //判断红或黑方，只能往前走
               if (BoolColor)
               {
                   if (chess.PressX == LocationX && chess.PressY == (LocationY + 1))
                       return true;
                   else if (chess.PressY == LocationY && (chess.PressX == (LocationX - 1) || chess.PressX == (LocationX + 1)))
                       return true;
                   else
                       return false;
               }
               else
               {
                   if (chess.PressX == LocationX && chess.PressY == (LocationY - 1))
                       return true;
                   else if (chess.PressY == LocationY && (chess.PressX == (LocationX - 1) || chess.PressX == (LocationX + 1)))
                       return true;
                   else
                       return false;
 
               }
           }
           else
           {
               if (BoolColor)
               {
                   if (chess.PressX == LocationX && chess.PressY == (LocationY + 1))
                       return true;
                   else return false;
               }
               else
               {
                   if (chess.PressX == LocationX && chess.PressY == (LocationY - 1))
                       return true;
                   else return false;
               }
 
           }
       }

        public override string Name
        {
            get
            {
                if (this._Color == ChessColor.Red) return "兵";
                else return "卒";
            }
        }
    }
}
