using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfdbCsharpWrapper;

namespace WfdbToZedGraph
{
    class WfdbRecordWraperInstance : WfdbRecordWraper
    {
        public WfdbRecordWraperInstance(Record record)
            : base(record)
        { }
    }
}
