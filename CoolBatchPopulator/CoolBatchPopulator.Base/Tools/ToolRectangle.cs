using System;
using System.Windows.Forms;
using System.Drawing;


namespace CoolBatchPopulator
{
	/// <summary>
	/// Rectangle tool
	/// </summary>
	class ToolRectangle : ToolObject
	{
        private int Xini, Yini;

		public ToolRectangle()
		{
            //Cursor = new Cursor(GetType(), "Rectangle.cur");
		}

        public override void OnMouseDown(WorkArea workArea, MouseEventArgs e)
        {
            AddNewObject(workArea, new DrawRectangle(e.X, e.Y, 70, 40));
        }

        public override void OnMouseMove(WorkArea workArea, MouseEventArgs e)
        {
            workArea.Cursor = Cursor;

            if ( e.Button == MouseButtons.Left )
            {
                Point point = new Point(e.X, e.Y);
                workArea.GraphicsList[0].MoveHandleTo(point, 5);
                workArea.Refresh();
            }
        }
	}
}
