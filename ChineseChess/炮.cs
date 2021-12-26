using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChineseChessFinal
{
    public class 炮 : 棋子
    {

        public 炮(ChessColor color, int chessR)
        {
            _color = color;
            _chessR = chessR;
            _king = false;

        }

        //移动规则炮
        public override bool MoveRules(棋盘 chess)
        {
            chess._currentX = LocationX;
            chess._currentY = LocationY;

            //吃子时规则
            if (chess.Eat)
            {
                int num = 0;//记录路线中棋子个数参数
                if (chess.PressX == LocationX && chess.PressY > LocationY)
                {
                    for (chess._currentY = LocationY + 1; chess._currentY < chess.PressY; chess._currentY++)
                    {
                        棋子 qiZi = chess.record.Find(chess.SearchAll);
                        if (qiZi != null) num++;
                    }
                    if (num == 1) return true;
                }
                if (chess.PressX == LocationX && chess.PressY < LocationY)
                {
                    for (chess._currentY = LocationY - 1; chess._currentY > chess.PressY; chess._currentY--)
                    {
                        棋子 qiZi = chess.record.Find(chess.SearchAll);
                        if (qiZi != null) num++;
                    }
                    if (num == 1) return true;

                }
                if (chess.PressY == LocationY && chess.PressX > LocationX)
                {
                    for (chess._currentX = LocationX + 1; chess._currentX < chess.PressX; chess._currentX++)
                    {
                        棋子 qiZi = chess.record.Find(chess.SearchAll);
                        if (qiZi != null) num++;
                    }
                    if (num == 1) return true;

                }
                if (chess.PressY == LocationY && chess.PressX < LocationX)
                {
                    for (chess._currentX = LocationX - 1; chess._currentX > chess.PressX; chess._currentX--)
                    {
                        棋子 qiZi = chess.record.Find(chess.SearchAll);
                        if (qiZi != null) num++;
                    }
                    if (num == 1) return true;
                }
            }
            //不吃子时规则，和车相同
            else
            {
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
            }
            return false;
        }



        public override string Name
        {
            get
            {
                if (this._Color == ChessColor.Red) return "炮";
                else return "砲";
            }
        }
    }
}
