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
    class DrawDatabase: DrawRectangle
    {
        public DrawDatabase()
            : this(0, 0, 1, 1)
        {
        }


        public DrawDatabase(int x, int y, int width, int height)
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

            int x = _rect.X;
            int y = _rect.Y;
            int w = _rect.Width;
            int h = _rect.Height;
            int hElipse = (w/5);
            int hArco = hElipse / 2;
            int hReta = h - hArco;

            // g.DrawArc(pen, DrawRectangle.GetNormalizedRectangle(Rectangle), -270, 180);
            g.DrawArc(pen, x, y, w, hElipse, 0, 360);
            g.DrawArc(pen, x, y + hReta - hArco , w, hElipse, 360, 180);

            Point SE = new Point(x, y + hArco);             //SuperiorEsquerdo
            Point IE = new Point(x, y + hReta);     //InferioriEsquerdo

            Point SD = new Point(x + w, y + hArco);         //SuperiorDireito
            Point ID = new Point(x + w, y + hReta); //InferiorDireito

            g.DrawLine(pen, SE, IE);
            g.DrawLine(pen, SD, ID);

            //g.DrawRectangle(pen, x, y, w, h);

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