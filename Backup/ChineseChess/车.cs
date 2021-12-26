using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChessFinal
{
   public class 车 : 棋子
    {

       public 车(ChessColor color, int chessR)
       {
           _color = color;
           _chessR = chessR;
           _king = false;
       }
       
      
        //移动规则车
        public override bool MoveRules(棋盘 chess)
        {
            chess._currentX = LocationX;
            chess._currentY = LocationY;

            if (chess.PressX == LocationX && chess.PressY > LocationY)
            {
                for (chess._currentY = LocationY + 1; chess._currentY < chess.PressY; chess._currentY++)
                {
                    棋子 qiZi = chess.record.Find(chess.SearchAll);
                    if (qiZi != null) return false;
                }
                return true;
            }
            if (chess.PressX == LocationX && chess.PressY < LocationY)
            {
                for (chess._currentY = LocationY - 1; chess._currentY > chess.PressY; chess._currentY--)
                {
                    棋子 qiZi = chess.record.Find(chess.SearchAll);
                    if (qiZi != null) return false;
                }
                return true;
            }
            if (chess.PressY == LocationY && chess.PressX > LocationX)
            {
                for (chess._currentX = LocationX + 1; chess._currentX < chess.PressX; chess._currentX++)
                {
                    棋子 qiZi = chess.record.Find(chess.SearchAll);
                    if (qiZi != null) return false;
                }
                return true;
            }
            if (chess.PressY == LocationY && chess.PressX < LocationX)
            {
                for (chess._currentX = LocationX - 1; chess._currentX > chess.PressX; chess._currentX--)
                {
                    棋子 qiZi = chess.record.Find(chess.SearchAll);
                    if (qiZi != null) return false;
                }
                return true;
            }

            return false;
        }

 
       public override string Name
        {
            get
            {
                if (this._Color== ChessColor.Red) return "车";
                else return "車";
            }

        }
    }
}
