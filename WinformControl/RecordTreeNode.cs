using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfdbToZedGraph.WinformControl
{
    public class RecordTreeNode : TreeNode
    {
        public WfdbRecordWraper Record { get; set; }
        
        public RecordTreeNode()
            : base()
        { }

        public RecordTreeNode(string text)
            : base(text)
        { }

        public RecordTreeNode(WfdbRecordWraper record) : base()
        {
            this.Record = record;
            this.Text = this.Record.Name;
            foreach(WfdbSignalWraper signal in record.Signals)
            {
                SignalTreeNode s = new SignalTreeNode(signal);
                this.Nodes.Add(s);
            }
        }
        /// <summary>
        /// On work - removes only node, not record
        /// </summary>
        public void RemoveRecord()
        {
            this.Remove();
            this.Record.AutoRemove();
        }
    }
}
