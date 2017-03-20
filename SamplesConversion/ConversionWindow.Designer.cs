namespace WfdbToZedGraph.SamplesConversion
{
    partial class ConversionWindow
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerZedGraphsLowest = new System.Windows.Forms.SplitContainer();
            this.splitContainerZedGraphTop = new System.Windows.Forms.SplitContainer();
            this.zedGraphControlSource = new ZedGraph.ZedGraphControl();
            this.zedGraphControlNoise = new ZedGraph.ZedGraphControl();
            this.splitContainerZedGraphBottom = new System.Windows.Forms.SplitContainer();
            this.zedGraphControlSamples = new ZedGraph.ZedGraphControl();
            this.zedGraphControlRestored = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerZedGraphsLowest)).BeginInit();
            this.splitContainerZedGraphsLowest.Panel1.SuspendLayout();
            this.splitContainerZedGraphsLowest.Panel2.SuspendLayout();
            this.splitContainerZedGraphsLowest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerZedGraphTop)).BeginInit();
            this.splitContainerZedGraphTop.Panel1.SuspendLayout();
            this.splitContainerZedGraphTop.Panel2.SuspendLayout();
            this.splitContainerZedGraphTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerZedGraphBottom)).BeginInit();
            this.splitContainerZedGraphBottom.Panel1.SuspendLayout();
            this.splitContainerZedGraphBottom.Panel2.SuspendLayout();
            this.splitContainerZedGraphBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerZedGraphsLowest
            // 
            this.splitContainerZedGraphsLowest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerZedGraphsLowest.Location = new System.Drawing.Point(0, 0);
            this.splitContainerZedGraphsLowest.Name = "splitContainerZedGraphsLowest";
            this.splitContainerZedGraphsLowest.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerZedGraphsLowest.Panel1
            // 
            this.splitContainerZedGraphsLowest.Panel1.Controls.Add(this.splitContainerZedGraphTop);
            // 
            // splitContainerZedGraphsLowest.Panel2
            // 
            this.splitContainerZedGraphsLowest.Panel2.Controls.Add(this.splitContainerZedGraphBottom);
            this.splitContainerZedGraphsLowest.Size = new System.Drawing.Size(823, 761);
            this.splitContainerZedGraphsLowest.SplitterDistance = 382;
            this.splitContainerZedGraphsLowest.TabIndex = 0;
            // 
            // splitContainerZedGraphTop
            // 
            this.splitContainerZedGraphTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerZedGraphTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerZedGraphTop.Name = "splitContainerZedGraphTop";
            this.splitContainerZedGraphTop.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerZedGraphTop.Panel1
            // 
            this.splitContainerZedGraphTop.Panel1.Controls.Add(this.zedGraphControlSource);
            // 
            // splitContainerZedGraphTop.Panel2
            // 
            this.splitContainerZedGraphTop.Panel2.Controls.Add(this.zedGraphControlSamples);
            this.splitContainerZedGraphTop.Size = new System.Drawing.Size(823, 382);
            this.splitContainerZedGraphTop.SplitterDistance = 199;
            this.splitContainerZedGraphTop.TabIndex = 0;
            // 
            // zedGraphControlSource
            // 
            this.zedGraphControlSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlSource.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlSource.Name = "zedGraphControlSource";
            this.zedGraphControlSource.ScrollGrace = 0D;
            this.zedGraphControlSource.ScrollMaxX = 0D;
            this.zedGraphControlSource.ScrollMaxY = 0D;
            this.zedGraphControlSource.ScrollMaxY2 = 0D;
            this.zedGraphControlSource.ScrollMinX = 0D;
            this.zedGraphControlSource.ScrollMinY = 0D;
            this.zedGraphControlSource.ScrollMinY2 = 0D;
            this.zedGraphControlSource.Size = new System.Drawing.Size(823, 199);
            this.zedGraphControlSource.TabIndex = 0;
            // 
            // zedGraphControlNoise
            // 
            this.zedGraphControlNoise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlNoise.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlNoise.Name = "zedGraphControlNoise";
            this.zedGraphControlNoise.ScrollGrace = 0D;
            this.zedGraphControlNoise.ScrollMaxX = 0D;
            this.zedGraphControlNoise.ScrollMaxY = 0D;
            this.zedGraphControlNoise.ScrollMaxY2 = 0D;
            this.zedGraphControlNoise.ScrollMinX = 0D;
            this.zedGraphControlNoise.ScrollMinY = 0D;
            this.zedGraphControlNoise.ScrollMinY2 = 0D;
            this.zedGraphControlNoise.Size = new System.Drawing.Size(823, 183);
            this.zedGraphControlNoise.TabIndex = 0;
            // 
            // splitContainerZedGraphBottom
            // 
            this.splitContainerZedGraphBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerZedGraphBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerZedGraphBottom.Name = "splitContainerZedGraphBottom";
            this.splitContainerZedGraphBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerZedGraphBottom.Panel1
            // 
            this.splitContainerZedGraphBottom.Panel1.Controls.Add(this.zedGraphControlNoise);
            // 
            // splitContainerZedGraphBottom.Panel2
            // 
            this.splitContainerZedGraphBottom.Panel2.Controls.Add(this.zedGraphControlRestored);
            this.splitContainerZedGraphBottom.Size = new System.Drawing.Size(823, 375);
            this.splitContainerZedGraphBottom.SplitterDistance = 183;
            this.splitContainerZedGraphBottom.TabIndex = 0;
            // 
            // zedGraphControlSamples
            // 
            this.zedGraphControlSamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlSamples.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlSamples.Name = "zedGraphControlSamples";
            this.zedGraphControlSamples.ScrollGrace = 0D;
            this.zedGraphControlSamples.ScrollMaxX = 0D;
            this.zedGraphControlSamples.ScrollMaxY = 0D;
            this.zedGraphControlSamples.ScrollMaxY2 = 0D;
            this.zedGraphControlSamples.ScrollMinX = 0D;
            this.zedGraphControlSamples.ScrollMinY = 0D;
            this.zedGraphControlSamples.ScrollMinY2 = 0D;
            this.zedGraphControlSamples.Size = new System.Drawing.Size(823, 179);
            this.zedGraphControlSamples.TabIndex = 0;
            // 
            // zedGraphControlRestored
            // 
            this.zedGraphControlRestored.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlRestored.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControlRestored.Name = "zedGraphControlRestored";
            this.zedGraphControlRestored.ScrollGrace = 0D;
            this.zedGraphControlRestored.ScrollMaxX = 0D;
            this.zedGraphControlRestored.ScrollMaxY = 0D;
            this.zedGraphControlRestored.ScrollMaxY2 = 0D;
            this.zedGraphControlRestored.ScrollMinX = 0D;
            this.zedGraphControlRestored.ScrollMinY = 0D;
            this.zedGraphControlRestored.ScrollMinY2 = 0D;
            this.zedGraphControlRestored.Size = new System.Drawing.Size(823, 188);
            this.zedGraphControlRestored.TabIndex = 0;
            // 
            // ConversionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 761);
            this.Controls.Add(this.splitContainerZedGraphsLowest);
            this.Name = "ConversionWindow";
            this.Text = "ConversionWindow";
            this.Load += new System.EventHandler(this.ConversionWindow_Load);
            this.splitContainerZedGraphsLowest.Panel1.ResumeLayout(false);
            this.splitContainerZedGraphsLowest.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerZedGraphsLowest)).EndInit();
            this.splitContainerZedGraphsLowest.ResumeLayout(false);
            this.splitContainerZedGraphTop.Panel1.ResumeLayout(false);
            this.splitContainerZedGraphTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerZedGraphTop)).EndInit();
            this.splitContainerZedGraphTop.ResumeLayout(false);
            this.splitContainerZedGraphBottom.Panel1.ResumeLayout(false);
            this.splitContainerZedGraphBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerZedGraphBottom)).EndInit();
            this.splitContainerZedGraphBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerZedGraphsLowest;
        private System.Windows.Forms.SplitContainer splitContainerZedGraphTop;
        private System.Windows.Forms.SplitContainer splitContainerZedGraphBottom;
        private ZedGraph.ZedGraphControl zedGraphControlSource;
        private ZedGraph.ZedGraphControl zedGraphControlNoise;
        private ZedGraph.ZedGraphControl zedGraphControlSamples;
        private ZedGraph.ZedGraphControl zedGraphControlRestored;
    }
}