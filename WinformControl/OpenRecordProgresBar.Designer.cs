namespace WfdbToZedGraph.WinformControl
{
    partial class OpenRecordProgresBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
        private void InitializeComponent ()
        {
            this.progressBarCurrent = new System.Windows.Forms.ProgressBar();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarCurrent
            // 
            this.progressBarCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarCurrent.Location = new System.Drawing.Point(3, 16);
            this.progressBarCurrent.Name = "progressBarCurrent";
            this.progressBarCurrent.Size = new System.Drawing.Size(337, 23);
            this.progressBarCurrent.TabIndex = 1;
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(3, 0);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(35, 13);
            this.labelCurrent.TabIndex = 3;
            this.labelCurrent.Text = "label2";
            // 
            // OpenRecordProgresBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.progressBarCurrent);
            this.Name = "OpenRecordProgresBar";
            this.Size = new System.Drawing.Size(343, 51);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarCurrent;
        private System.Windows.Forms.Label labelCurrent;
    }
}
