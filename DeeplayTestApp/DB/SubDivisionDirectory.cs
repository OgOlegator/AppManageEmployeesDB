using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DeeplayTestApp.DB
{
    public class SubDivisionDirectory
    {
        private List<string> _directorySubDivision;

        private employeesDataSetTableAdapters.SubdivisionTableAdapter _subDivisionTableAdapter
            = new employeesDataSetTableAdapters.SubdivisionTableAdapter();

        public SubDivisionDirectory()
        { }

        public List<string> GetDirectorySubDivison()
        {
            if (_directorySubDivision == null)
                SetDirectorySubDivision();

            return _directorySubDivision;
        }

        private void SetDirectorySubDivision()
        {
            _directorySubDivision = new List<string>();

            var subDivisionDbData = _subDivisionTableAdapter.GetData();

            foreach (DataRow subDivision in subDivisionDbData.Rows)
            {
                _directorySubDivision.Add(subDivision.ItemArray[0].ToString());
            }
        }
    }
}
