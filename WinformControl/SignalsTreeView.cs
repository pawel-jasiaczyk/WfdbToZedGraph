using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ZedGraph;

namespace WfdbToZedGraph.WinformControl
{
    public class SignalsTreeView : TreeView
    {
        #region Fields

        private ZedGraph.ZedGraphControl zedGraph;

        #endregion

        #region Properties

        public ZedGraphControl ZedGraphConrol 
        { 
            get { return this.zedGraph; }
            set { this.zedGraph = value; }
        }

        #endregion

        #region Constructors

        public SignalsTreeView() : base()
        {
            this.CheckBoxes = true;
            this.EventsConfiguration();
        }

        public SignalsTreeView(ZedGraphControl zedGraphControl) : this()
        {
            this.zedGraph = zedGraphControl;
        }

        #endregion

        #region Events
        
        private void EventsConfiguration()
        {
            this.AfterCheck += SignalsTreeView_AfterCheck;
        }

        void SignalsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node is RecordTreeNode)
            {
                foreach(TreeNode node in e.Node.Nodes)
                {
                    node.Checked = e.Node.Checked;
                }
            }
        }

        #endregion

        public void LoadToGraph()
        {
            this.zedGraph.Enabled = false;
            foreach(TreeNode rec in this.Nodes)
            {
                if(rec is RecordTreeNode)
                {
                    foreach(TreeNode sign in rec.Nodes)
                    {
                        if (sign is SignalTreeNode)
                        {
                            SignalTreeNode s = (SignalTreeNode)sign;
                            if (s.Checked)
                            {
                                if (s.Curve == null)
                                {
                                    s.Curve =
                                        this.zedGraph.GraphPane.AddCurve
                                        (s.Name, s.Signal.GetSamples(), Color.Black, SymbolType.None);
                                }
                                else if(!this.zedGraph.GraphPane.CurveList.Contains(s.Curve))
                                {
                                    this.zedGraph.GraphPane.CurveList.Add(s.Curve);
                                }
                            }
                            else
                            {
                                if(s.Curve != null 
                                    && this.zedGraph.GraphPane.CurveList.Contains(s.Curve))
                                {
                                    this.zedGraph.GraphPane.CurveList.Remove(s.Curve);
                                }
                            }
                        }
                    }
                }
            }
            this.zedGraph.Enabled = true;
            this.zedGraph.AxisChange();
            this.zedGraph.Refresh();
        }
    }
}
