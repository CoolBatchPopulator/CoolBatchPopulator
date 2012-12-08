namespace CoolBatchPopulator
{
    partial class frmCoolBatchPopulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoolBatchPopulator));
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.tbPointer = new System.Windows.Forms.ToolStripButton();
            this.tbFile = new System.Windows.Forms.ToolStripButton();
            this.tbDatabase = new System.Windows.Forms.ToolStripButton();
            this.tbProcess = new System.Windows.Forms.ToolStripButton();
            this.tbConnector = new System.Windows.Forms.ToolStripButton();
            this.workArea = new CoolBatchPopulator.WorkArea();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbPointer,
            this.tbFile,
            this.tbDatabase,
            this.tbProcess,
            this.tbConnector});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(565, 25);
            this.toolBar.TabIndex = 1;
            this.toolBar.Text = "toolStrip1";
            // 
            // tbPointer
            // 
            this.tbPointer.Image = ((System.Drawing.Image)(resources.GetObject("tbPointer.Image")));
            this.tbPointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPointer.Name = "tbPointer";
            this.tbPointer.Size = new System.Drawing.Size(61, 22);
            this.tbPointer.Text = "Pointer";
            this.tbPointer.Click += new System.EventHandler(this.tbPointer_Click);
            // 
            // tbFile
            // 
            this.tbFile.Image = ((System.Drawing.Image)(resources.GetObject("tbFile.Image")));
            this.tbFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(43, 22);
            this.tbFile.Text = "File";
            this.tbFile.Click += new System.EventHandler(this.tbFile_Click);
            // 
            // tbDatabase
            // 
            this.tbDatabase.Image = ((System.Drawing.Image)(resources.GetObject("tbDatabase.Image")));
            this.tbDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(73, 22);
            this.tbDatabase.Text = "Database";
            this.tbDatabase.Click += new System.EventHandler(this.tbDatabase_Click);
            // 
            // tbProcess
            // 
            this.tbProcess.Image = ((System.Drawing.Image)(resources.GetObject("tbProcess.Image")));
            this.tbProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.Size = new System.Drawing.Size(64, 22);
            this.tbProcess.Text = "Process";
            this.tbProcess.Click += new System.EventHandler(this.tbProcess_Click);
            // 
            // tbConnector
            // 
            this.tbConnector.Image = ((System.Drawing.Image)(resources.GetObject("tbConnector.Image")));
            this.tbConnector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConnector.Name = "tbConnector";
            this.tbConnector.Size = new System.Drawing.Size(77, 22);
            this.tbConnector.Text = "Connector";
            this.tbConnector.Click += new System.EventHandler(this.tbConnector_Click);
            // 
            // workArea
            // 
            this.workArea.ActiveTool = CoolBatchPopulator.DrawToolType.Pointer;
            this.workArea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.workArea.GraphicsList = null;
            this.workArea.Location = new System.Drawing.Point(555, 365);
            this.workArea.Name = "workArea";
            this.workArea.Size = new System.Drawing.Size(10, 10);
            this.workArea.TabIndex = 0;
            // 
            // frmCoolBatchPopulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 395);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.workArea);
            this.Name = "frmCoolBatchPopulator";
            this.Load += new System.EventHandler(this.frmCoolBatchPopulator_Load);
            this.Resize += new System.EventHandler(this.frmCoolBatchPopulator_Resize);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WorkArea workArea;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton tbPointer;
        private System.Windows.Forms.ToolStripButton tbFile;
        private System.Windows.Forms.ToolStripButton tbDatabase;
        private System.Windows.Forms.ToolStripButton tbProcess;
        private System.Windows.Forms.ToolStripButton tbConnector;

    }
}

