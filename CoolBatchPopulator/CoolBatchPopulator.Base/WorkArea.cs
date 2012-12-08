using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoolBatchPopulator
{
    public partial class WorkArea : UserControl
    {

        #region Members

        private GraphicsList graphicsList;    // list of draw objects
        // (instances of DrawObject-derived classes)

        private DrawToolType activeTool;      // active drawing tool
        private Tool[] tools;                // array of tools

        #endregion

        #region Properties

        public DrawToolType ActiveTool
        {
            get
            {
                return activeTool;
            }
            set
            {
                activeTool = value;
            }
        }

        public GraphicsList GraphicsList
        {
            get
            {
                return graphicsList;
            }
            set
            {
                graphicsList = value;
            }
        }

        #endregion

        #region Other Functions

        public void Initialize()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            activeTool = DrawToolType.Pointer;

            graphicsList = new GraphicsList();

            tools = new Tool[(int)DrawToolType.NumberOfTools];
            tools[(int)DrawToolType.Pointer] = new ToolPointer();
            //tools[(int)DrawToolType.File] = new ToolRectangle();
            //tools[(int)DrawToolType.Database] = new ToolEllipse();
            // Evandro tools[(int)DrawToolType.Process] = new ToolLine();
            tools[(int)DrawToolType.Process] = new ToolRectangle();
            //tools[(int)DrawToolType.Connector] = new ToolPolygon();
        }

        #endregion

        public WorkArea()
        {
            InitializeComponent();
            Initialize();
        }

        #region - Event Handlers -

        private void WorkArea_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
            e.Graphics.FillRectangle(brush,
                this.ClientRectangle);

            if (graphicsList != null)
            {
                graphicsList.Draw(e.Graphics);
            }

            brush.Dispose();
        }

             /// <summary>
        /// Mouse down.
        /// Left button down event is passed to active tool.
        /// Right button down event is handled in this class.
        /// </summary>
        private void WorkArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tools[(int)activeTool].OnMouseDown(this, e);
            //else if (e.Button == MouseButtons.Right)
                //OnContextMenu(e);
        }

        /// <summary>
        /// Mouse move.
        /// Moving without button pressed or with left button pressed
        /// is passed to active tool.
        /// </summary>
        private void WorkArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
                tools[(int)activeTool].OnMouseMove(this, e);
            else
                this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Mouse up event.
        /// Left button up event is passed to active tool.
        /// </summary>
        private void WorkArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tools[(int)activeTool].OnMouseUp(this, e);
        }

        #endregion - Event Handlers -
    }
}
