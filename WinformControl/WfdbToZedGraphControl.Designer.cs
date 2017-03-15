namespace WfdbToZedGraph.WinformControl
{
    partial class WfdbToZedGraphControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerTree = new System.Windows.Forms.SplitContainer();
            this.splitContainerControls = new System.Windows.Forms.SplitContainer();
            this.buttonRun = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.contextMenuStripSignalNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripRecordNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveRecordToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEmptyRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signalsTreeView = new WfdbToZedGraph.WinformControl.SignalsTreeView();
            this.addSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTree)).BeginInit();
            this.splitContainerTree.Panel1.SuspendLayout();
            this.splitContainerTree.Panel2.SuspendLayout();
            this.splitContainerTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControls)).BeginInit();
            this.splitContainerControls.Panel1.SuspendLayout();
            this.splitContainerControls.Panel2.SuspendLayout();
            this.splitContainerControls.SuspendLayout();
            this.contextMenuStripSignalNode.SuspendLayout();
            this.contextMenuStripRecordNode.SuspendLayout();
            this.contextMenuStripTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerTree
            // 
            this.splitContainerTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTree.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTree.Name = "splitContainerTree";
            this.splitContainerTree.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTree.Panel1
            // 
            this.splitContainerTree.Panel1.Controls.Add(this.signalsTreeView);
            // 
            // splitContainerTree.Panel2
            // 
            this.splitContainerTree.Panel2.Controls.Add(this.splitContainerControls);
            this.splitContainerTree.Size = new System.Drawing.Size(287, 560);
            this.splitContainerTree.SplitterDistance = 280;
            this.splitContainerTree.TabIndex = 2;
            // 
            // splitContainerControls
            // 
            this.splitContainerControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControls.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControls.Name = "splitContainerControls";
            // 
            // splitContainerControls.Panel1
            // 
            this.splitContainerControls.Panel1.Controls.Add(this.buttonRun);
            // 
            // splitContainerControls.Panel2
            // 
            this.splitContainerControls.Panel2.Controls.Add(this.textBoxInfo);
            this.splitContainerControls.Size = new System.Drawing.Size(287, 276);
            this.splitContainerControls.SplitterDistance = 95;
            this.splitContainerControls.TabIndex = 0;
            // 
            // buttonRun
            // 
            this.buttonRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRun.Location = new System.Drawing.Point(0, 0);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(95, 276);
            this.buttonRun.TabIndex = 0;
            this.buttonRun.Text = "Load Data To Graph";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInfo.Location = new System.Drawing.Point(0, 0);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInfo.Size = new System.Drawing.Size(188, 276);
            this.textBoxInfo.TabIndex = 0;
            // 
            // contextMenuStripSignalNode
            // 
            this.contextMenuStripSignalNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStripSignalNode.Name = "contextMenuStrip1";
            this.contextMenuStripSignalNode.Size = new System.Drawing.Size(118, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem1.Text = "Remove";
            // 
            // contextMenuStripRecordNode
            // 
            this.contextMenuStripRecordNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeRecordToolStripMenuItem,
            this.saveRecordToCSVToolStripMenuItem,
            this.addSignalToolStripMenuItem});
            this.contextMenuStripRecordNode.Name = "contextMenuStripRecordNode";
            this.contextMenuStripRecordNode.Size = new System.Drawing.Size(177, 92);
            this.contextMenuStripRecordNode.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripRecordNode_Opening);
            // 
            // removeRecordToolStripMenuItem
            // 
            this.removeRecordToolStripMenuItem.Name = "removeRecordToolStripMenuItem";
            this.removeRecordToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.removeRecordToolStripMenuItem.Text = "Remove Record";
            this.removeRecordToolStripMenuItem.Click += new System.EventHandler(this.removeRecordToolStripMenuItem_Click);
            // 
            // saveRecordToCSVToolStripMenuItem
            // 
            this.saveRecordToCSVToolStripMenuItem.Name = "saveRecordToCSVToolStripMenuItem";
            this.saveRecordToCSVToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.saveRecordToCSVToolStripMenuItem.Text = "Save Record to CSV";
            this.saveRecordToCSVToolStripMenuItem.Click += new System.EventHandler(this.saveRecordToCSVToolStripMenuItem_Click);
            // 
            // contextMenuStripTree
            // 
            this.contextMenuStripTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEmptyRecordToolStripMenuItem});
            this.contextMenuStripTree.Name = "contextMenuStripTree";
            this.contextMenuStripTree.Size = new System.Drawing.Size(174, 26);
            // 
            // addEmptyRecordToolStripMenuItem
            // 
            this.addEmptyRecordToolStripMenuItem.Name = "addEmptyRecordToolStripMenuItem";
            this.addEmptyRecordToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addEmptyRecordToolStripMenuItem.Text = "Add Empty Record";
            this.addEmptyRecordToolStripMenuItem.Click += new System.EventHandler(this.addEmptyRecordToolStripMenuItem_Click);
            // 
            // signalsTreeView
            // 
            this.signalsTreeView.CheckBoxes = true;
            this.signalsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalsTreeView.Location = new System.Drawing.Point(0, 0);
            this.signalsTreeView.Name = "signalsTreeView";
            this.signalsTreeView.Size = new System.Drawing.Size(287, 280);
            this.signalsTreeView.TabIndex = 0;
            this.signalsTreeView.ZedGraphConrol = null;
            this.signalsTreeView.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.signalsTreeView_NodeMouseHover);
            this.signalsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.signalsTreeView_NodeMouseClick);
            this.signalsTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.signalsTreeView_MouseDown);
            // 
            // addSignalToolStripMenuItem
            // 
            this.addSignalToolStripMenuItem.Name = "addSignalToolStripMenuItem";
            this.addSignalToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.addSignalToolStripMenuItem.Text = "Add Signal";
            this.addSignalToolStripMenuItem.Click += new System.EventHandler(this.addSignalToolStripMenuItem_Click);
            // 
            // WfdbToZedGraphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerTree);
            this.Name = "WfdbToZedGraphControl";
            this.Size = new System.Drawing.Size(287, 560);
            this.splitContainerTree.Panel1.ResumeLayout(false);
            this.splitContainerTree.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTree)).EndInit();
            this.splitContainerTree.ResumeLayout(false);
            this.splitContainerControls.Panel1.ResumeLayout(false);
            this.splitContainerControls.Panel2.ResumeLayout(false);
            this.splitContainerControls.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControls)).EndInit();
            this.splitContainerControls.ResumeLayout(false);
            this.contextMenuStripSignalNode.ResumeLayout(false);
            this.contextMenuStripRecordNode.ResumeLayout(false);
            this.contextMenuStripTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTree;
        private SignalsTreeView signalsTreeView;
        private System.Windows.Forms.SplitContainer splitContainerControls;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSignalNode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRecordNode;
        private System.Windows.Forms.ToolStripMenuItem removeRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveRecordToCSVToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTree;
        private System.Windows.Forms.ToolStripMenuItem addEmptyRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSignalToolStripMenuItem;
    }
}
