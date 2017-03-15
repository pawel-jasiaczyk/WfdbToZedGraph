using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfdbToZedGraph.WinformControl
{
    public partial class WfdbToZedGraphControl : UserControl
    {
        #region Fields

        private ToolTip currentTip;

        #endregion

        #region Properties

        public ZedGraph.ZedGraphControl ZedGraphControl 
        {
            get { return this.signalsTreeView.ZedGraphConrol; }
            set { this.signalsTreeView.ZedGraphConrol = value; }
        }
        public WfdbToZedGraphBinder WfdbBinder { get; set; }
        public TreeNodeCollection TreeNodes { get { return this.signalsTreeView.Nodes; } }

        #endregion

        #region Events

        public event TreeViewEventHandler AddNewSignal;

        #endregion

        #region Constructors

        public WfdbToZedGraphControl()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        #region Buttons

        private void buttonRun_Click(object sender, EventArgs e)
        {
            try
            {
                this.signalsTreeView.LoadToGraph();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region TreeView

        #region Mouse

        private void signalsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (e.Node is SignalTreeNode)
                    this.textBoxInfo.Text = (e.Node as SignalTreeNode).GetInfo();
                if (e.Node is RecordTreeNode)
                    this.textBoxInfo.Clear();
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.signalsTreeView.SelectedNode = e.Node;
                if (e.Node is SignalTreeNode)
                {
                    this.contextMenuStripSignalNode.Show(this.signalsTreeView, p);
                    this.textBoxInfo.Text = (e.Node as SignalTreeNode).GetInfo();
                }
                if(e.Node is RecordTreeNode)
                {
                    this.textBoxInfo.Clear();
                    this.contextMenuStripRecordNode.Show(this.signalsTreeView, p);
                }
            }
        }

        private void signalsTreeView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if(e.Node is SignalTreeNode)
            {
                if (currentTip != null)
                    currentTip.Active = false;
                currentTip = new ToolTip();
                currentTip.Show((e.Node as SignalTreeNode).GetInfo(), this.signalsTreeView);
            }
            if (e.Node is RecordTreeNode)
                if (currentTip != null && currentTip.Active)
                    currentTip.Active = false;
        }

        private void signalsTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.contextMenuStripTree.Show(this.signalsTreeView, p);
            }
        }

        #endregion

        #region MenuClicks

        private void removeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordTreeNode node = (this.signalsTreeView.SelectedNode as RecordTreeNode);
            if(node != null)
            {
                // MessageBox.Show(node.Record.Name);
                List<SignalTreeNode> loaded = new List<SignalTreeNode>();
                foreach(TreeNode signode in node.Nodes)
                {
                    SignalTreeNode sigNode = signode as SignalTreeNode;
                    if(sigNode != null)
                    {
                        if(this.ZedGraphControl.GraphPane.CurveList.Contains(sigNode.Curve))
                        {
                            loaded.Add(sigNode);
                        }
                    }
                }
                if(loaded.Count != 0)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    string title = "";
                    string message = "This signals are loaded: \n\r";
                    foreach(SignalTreeNode s in loaded)
                    {
                        message += s.Signal.SignalNumber +  "\n\r"; 
                    }
                    message += "If you confirm, you will loose control about them from this control";
                    if(MessageBox.Show(message, title, buttons) == DialogResult.Yes)
                    {
                        node.RemoveRecord();
                    }
                }
                else
                    node.RemoveRecord();
            }
        }

        private void saveRecordToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordTreeNode recNode = this.signalsTreeView.SelectedNode as RecordTreeNode;
            if(recNode != null)
            {
                // MessageBox.Show(recNode.Record.GetCsvString().Substring(0, 1000));
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "csv";
                if (string.IsNullOrEmpty(recNode.Record.Name))
                    sfd.FileName = "newFile";
                else
                    sfd.FileName = recNode.Record.Name;
                if (sfd.ShowDialog() == DialogResult.OK)
                    WfdbToZedGraph.LocalFilesManager.WfdbLocalFilesManager.SaveTextFile
                        (recNode.Record.GetCsvString(), sfd.FileName);
            }
        }

        #endregion

        private void addEmptyRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WfdbRecordWraper rec = this.WfdbBinder.CreateEmptyRecord("test");
            RecordTreeNode node = new RecordTreeNode(rec);
            this.TreeNodes.Add(node);
        }

        #endregion

        private void contextMenuStripRecordNode_Opening(object sender, CancelEventArgs e)
        {
            if (this.AddNewSignal == null)
                addSignalToolStripMenuItem.Enabled = false;
            else
            {
                addSignalToolStripMenuItem.Enabled = true;
            }
        }

        #endregion

        private void addSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.AddNewSignal != null)
                AddNewSignal (
                    this.signalsTreeView, 
                    new TreeViewEventArgs(this.signalsTreeView.SelectedNode)
                    );
        }
    }
}
