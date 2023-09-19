using SyncModule.GisDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncModule.GisDataSetTableAdapters
{
    public class vwCustomSITTableAdapter:vwSITTableAdapter
    {
        public int FillByMaxID(GisDataSet.vwSITDataTable dataTable,int timeOut)
        {
            this.CommandCollection[1].CommandTimeout = timeOut;
            return base.FillByMaxID(dataTable);
        }
    }
}
