using System;
using System.Windows.Forms;
using System.Drawing;

namespace CoolBatchPopulator
{
	/// <summary>
	/// Line tool
	/// </summary>
	class ToolFileForm : ToolObject
	{
        public ToolFileForm()
        {
            //Cursor = new Cursor(GetType(), "Line.cur");
        }

        public override void OnMouseDown(WorkArea workArea, MouseEventArgs e)
        {
            AddNewObject(workArea, new DrawArc(e.X, e.Y, e.X + 1, e.Y + 1));
        }

        public override void OnMouseMove(WorkArea workArea, MouseEventArgs e)
        {
            workArea.Cursor = Cursor;

            if ( e.Button == MouseButtons.Left )
            {
                Point point = new Point(e.X, e.Y);
                workArea.GraphicsList[0].MoveHandleTo(point, 2);
                workArea.Refresh();
            }
        }
    }
}
