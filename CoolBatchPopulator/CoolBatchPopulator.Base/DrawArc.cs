using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;

namespace CoolBatchPopulator
{
    /// <summary>
    /// Rectangle graphic object
    /// </summary>
    class DrawArc: DrawRectangle
    {
        public DrawArc()
            : this(0, 0, 1, 1)
        {
        }


        public DrawArc(int x, int y, int width, int height)
            : base()
        {
            Rectangle = new Rectangle(x, y, width, height);
            Initialize(Color.Black, 1);
        }

        /// <summary>
        /// Draw rectangle
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, PenWidth);

            Rectangle _rect = new Rectangle();
            _rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

            int _x = _rect.X;
            int _y = _rect.Y;
            int _width = _rect.Width;
            int _height = _rect.Height;
            int _widthArc = (int)(_width * (0.42f));

            if (_x == 0) { _x = 1; }
            if (_y == 0) { _y = 1; }
            if (_width == 0) { _width = 1; }
            if (_height == 0) { _height = 1; }

            // g.DrawArc(pen, DrawRectangle.GetNormalizedRectangle(Rectangle), -270, 180);
            g.DrawArc(pen, _x,             _y, _width, _height, -270, 180);
            g.DrawArc(pen, _x + _widthArc, _y, _width, _height, -270, 180);

            g.DrawLine(pen, (int) (_x + _widthArc), _y,           (int) (_x + (_width - _widthArc)), _y);
            g.DrawLine(pen, (int) (_x + _widthArc), _y + _height, (int) (_x + (_width - _widthArc)), _y + _height);
            

            pen.Dispose();
        }

        /// <summary>
        /// Move handle to new point (resizing)
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            int left = Rectangle.Left;
            int top = Rectangle.Top;
            int right = Rectangle.Right;
            int bottom = Rectangle.Bottom;

            switch (handleNumber)
            {
                case 1:
                    left = point.X;
                    top = point.Y;
                    break;
                case 2:
                    top = point.Y;
                    break;
                case 3:
                    right = point.X;
                    top = point.Y;
                    break;
                case 4:
                    right = point.X;
                    break;
                case 5:
                    right = point.X;
                    bottom = point.Y;
                    break;
                case 6:
                    bottom = point.Y;
                    break;
                case 7:
                    left = point.X;
                    bottom = point.Y;
                    break;
                case 8:
                    left = point.X;
                    break;
            }

            SetRectangle(left, top, right - left, bottom - top);
        }



   }
}