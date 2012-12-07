using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoolBatchPopulator
{
    public partial class frmCoolBatchPopulator : Form
    {
        public frmCoolBatchPopulator()
        {
            InitializeComponent();
        }

        #region - Events -

        private void frmCoolBatchPopulator_Load(object sender, EventArgs e)
        {

            workArea = new WorkArea();
            workArea.Location = new System.Drawing.Point(0, 0);
            workArea.Size = new System.Drawing.Size(10, 10);
            this.Controls.Add(workArea);
                     
            workArea.Initialize();

            ResizeWorkArea();
        }

        private void frmCoolBatchPopulator_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                ResizeWorkArea();
            }

        }

        #endregion



        /// <summary>
        /// Set draw area to all form client space except toolbar
        /// </summary>
        private void ResizeWorkArea()
        {
            Rectangle rect = this.ClientRectangle;

            workArea.Left = rect.Left;
            workArea.Top = rect.Top  + toolBar.Height;
            workArea.Width = rect.Width;
            workArea.Height = rect.Height - toolBar.Height;
        }

        private void CommandPointer()
        {
            workArea.ActiveTool = DrawToolType.Pointer;
        }


        private void CommandFile()
        {
            workArea.ActiveTool = DrawToolType.File;
        }


        private void CommandDatabase()
        {
            workArea.ActiveTool = DrawToolType.Database;
        }

        private void CommandProcess()
        {
            workArea.ActiveTool = DrawToolType.Process;
        }

        private void CommandConnector()
        {
            workArea.ActiveTool = DrawToolType.Connector;
        }

        private void tbPointer_Click(object sender, EventArgs e)
        {
            CommandPointer();
        }

        private void tbFile_Click(object sender, EventArgs e)
        {
            CommandFile();
        }

        private void tbDatabase_Click(object sender, EventArgs e)
        {
            CommandDatabase();
        }

        private void tbProcess_Click(object sender, EventArgs e)
        {
            CommandProcess();
        }

        private void tbConnector_Click(object sender, EventArgs e)
        {
            CommandProcess();
        }


   }
}
