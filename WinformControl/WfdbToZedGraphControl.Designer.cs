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
            this.splitContainerTree = new System.Windows.Forms.SplitContainer();
            this.splitContainerControls = new System.Windows.Forms.SplitContainer();
            this.buttonRun = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.signalsTreeView = new WfdbToZedGraph.WinformControl.SignalsTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTree)).BeginInit();
            this.splitContainerTree.Panel1.SuspendLayout();
            this.splitContainerTree.Panel2.SuspendLayout();
            this.splitContainerTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControls)).BeginInit();
            this.splitContainerControls.Panel1.SuspendLayout();
            this.splitContainerControls.Panel2.SuspendLayout();
            this.splitContainerControls.SuspendLayout();
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
            // signalsTreeView
            // 
            this.signalsTreeView.CheckBoxes = true;
            this.signalsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalsTreeView.Location = new System.Drawing.Point(0, 0);
            this.signalsTreeView.Name = "signalsTreeView";
            this.signalsTreeView.Size = new System.Drawing.Size(287, 280);
            this.signalsTreeView.TabIndex = 0;
            this.signalsTreeView.ZedGraphConrol = null;
            this.signalsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.signalsTreeView_NodeMouseClick);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTree;
        private SignalsTreeView signalsTreeView;
        private System.Windows.Forms.SplitContainer splitContainerControls;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TextBox textBoxInfo;
    }
}
