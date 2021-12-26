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
    public abstract class 棋子
    {

        public ChessColor _color;
        public int _chessR;
        int _locationX, _locationY;
        int _pictureX, _pictureY;
        public bool _choose = false, _king = false;

        public virtual string Name
        {
            get { return null; }
        }

        public bool King
        {
            get { return _king; }
        }

        public ChessColor _Color
        {
            get { return this._color; }
        }

        public string PaintColor
        {
            get
            {
                if (this._Color == ChessColor.Red) { return "红"; }
                else { return "黑"; }
            }
        }

        public bool BoolColor
        {
            get
            {
                if (this._Color == ChessColor.Red) { return true; }
                else { return false; }
            }
        }

        public string Choose
        {
            get
            {
                if (_choose) return "已选";
                else return "未选";
            }
        }
        public int LocationX
        {
            set { _locationX  = value; }
            get { return _locationX; }
        }
        public int LocationY
        {
            set { _locationY = value; }
            get { return _locationY; }
        }
        public int PictureX
        {
            set { _pictureX = value; }
            get { return _pictureX; }
        }
        public int PictureY
        {
            set { _pictureY = value; }
            get { return _pictureY; }
        }
        public int ChessR
        {
            get { return _chessR; }
        }


        public void Draw(棋盘 chess,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //棋子格式
            Pen q;
            Font myFont = new Font("楷体", chess.StandardR / 2);
            SolidBrush MyBrush;
            int r;

            if (!_choose)
            {
                q = new Pen(Color.BurlyWood, 4);
            }
            else
            {
                q = new Pen(Color.Orange, 4);
 
            }
            if (BoolColor)
            {
                MyBrush = new SolidBrush(Color.Brown);
            }
            else
            {
                MyBrush = new SolidBrush(Color.Green);
            }

            g.TranslateTransform(PictureX , PictureY);
            for (r = 0; r < 360; r++)
            {
                g.RotateTransform(r);
                g.DrawLine(q, 0, 0, ChessR, 0);
            }
            g.ResetTransform();
            g.DrawString(Name , myFont, MyBrush, new PointF( PictureX - ChessR - (ChessR * 2 /25), PictureY - ChessR + (ChessR * 4 / 25)));

        }

        public abstract bool MoveRules(棋盘 chess);


    }

    public enum ChessColor
    {
        Red,
        Black
    }
}