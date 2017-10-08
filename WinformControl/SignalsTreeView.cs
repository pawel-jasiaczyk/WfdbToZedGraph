using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ZedGraph;
using System.Threading;

namespace WfdbToZedGraph.WinformControl
{
    public class SignalsTreeView : TreeView
    {
        #region Fields

        private ZedGraph.ZedGraphControl zedGraph;
        private Object thisLock = new Object();
        private OpenrecordProgressBarPopUp popup;
        private List<PointPairList> pointPairLists;

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
            this.pointPairLists = new List<PointPairList>();
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
            GetProbes(true);
        }

        public List<PointPairList> GetProbes(bool loadToZedGraph)
        {
            if(loadToZedGraph) this.zedGraph.Enabled = false;
            //popup = new OpenrecordProgressBarPopUp();
            //popup.Show();
            foreach (TreeNode rec in this.Nodes)
            {
                if (rec is RecordTreeNode)
                {
                    foreach (TreeNode sign in rec.Nodes)
                    {
                        if (sign is SignalTreeNode)
                        {
                            SignalTreeNode s = (SignalTreeNode)sign;
                            if (s.Checked)
                            {
                                //popup.AddSignal(s.Signal);
                                if (s.Curve == null)
                                {
                                    PointPairList p = s.Signal.GetSamples();
                                    this.pointPairLists.Add(p);
                                    if (loadToZedGraph)
                                    {
                                        s.Curve =
                                            this.zedGraph.GraphPane.AddCurve
                                            (s.Name, p, Color.Black, SymbolType.None);
                                    }
                                }
                                else if (!this.zedGraph.GraphPane.CurveList.Contains(s.Curve) && loadToZedGraph)
                                {
                                    this.zedGraph.GraphPane.CurveList.Add(s.Curve);
                                }
                            }
                            else
                            {
                                if (s.Curve != null
                                    && this.zedGraph.GraphPane.CurveList.Contains(s.Curve)
                                    && loadToZedGraph)
                                {
                                    this.zedGraph.GraphPane.CurveList.Remove(s.Curve);
                                }
                            }
                        }
                    }
                }
            }
            if (loadToZedGraph)
            {
                this.zedGraph.Enabled = true;
                this.zedGraph.AxisChange();
                this.zedGraph.Refresh();
            }
            return this.pointPairLists;
        }

    }
}
