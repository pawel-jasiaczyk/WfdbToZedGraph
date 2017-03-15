using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfdbCsharpWrapper;

namespace WfdbToZedGraph
{
    internal class WfdbRecordWraperInstance : WfdbRecordWraper
    {
        public WfdbRecordWraperInstance(Record record)
            : base(record)
        { }

        public WfdbRecordWraperInstance(string name)
            : base(name)
        { }

        public void SetUseTemp(bool useTemp) 
        {
            this.UseTemp = useTemp;
        }
    }
}
