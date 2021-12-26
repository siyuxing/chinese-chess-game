using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChessFinal
{
    public class 马 : 棋子
    {

        public 马(ChessColor color,int chessR)
        {
            _color = color;
            _chessR = chessR;
            _king = false;

        }

        //移动规则马,包含别退的判断
        public override bool MoveRules(棋盘 chess)
        {
            if ((chess.PressX == (LocationX - 1) || chess.PressX == (LocationX + 1))
                && (chess.PressY == (LocationY - 2) || chess.PressY == (LocationY + 2)))
            {
                chess._currentX = LocationX;
                chess._currentY = (chess.PressY + LocationY) / 2;
                棋子 qiZi = chess.record.Find(chess.SearchAll);
                if (qiZi != null)
                {
                    Console.WriteLine("别腿！！");
                    return false;

                }
                else return true;
 
            }
            else if ((chess.PressX == (LocationX - 2) || chess.PressX == (LocationX + 2))
                   && (chess.PressY == (LocationY - 1) || chess.PressY == (LocationY + 1)))
            {
                chess._currentX = (chess.PressX + LocationX) / 2;
                chess._currentY = LocationY;
                棋子 qiZi = chess.record.Find(chess.SearchAll);
                if (qiZi != null)
                {
                    Console.WriteLine("别腿！！");
                    return false;

                }
                else return true;
 
            }
            return false;
        }

        public override string Name
        {
            get
            {
                if (this._Color == ChessColor.Red) return "马";
                else return "馬";
            }
        }
    }
}
