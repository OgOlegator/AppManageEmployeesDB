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
        private List<StrucSubDivision> _directorySubDivision;

        public struct StrucSubDivision
        {
            public string Name;
        }

        private employeesDataSetTableAdapters.SubdivisionTableAdapter _subDivisionTableAdapter
            = new employeesDataSetTableAdapters.SubdivisionTableAdapter();

        public SubDivisionDirectory()
        { }

        public List<StrucSubDivision> GetDirectorySubDivison()
        {
            if (_directorySubDivision == null)
                SetDirectorySubDivision();

            return _directorySubDivision;
        }

        public List<string> GetSubDivisions()
            => GetDirectorySubDivison().Select(x => x.Name).ToList();

        private void SetDirectorySubDivision()
        {
            _directorySubDivision = new List<StrucSubDivision>();

            var subDivisionDbData = _subDivisionTableAdapter.GetData();

            foreach (DataRow subDivision in subDivisionDbData.Rows)
            {
                _directorySubDivision.Add(new StrucSubDivision { Name = subDivision.ItemArray[0].ToString() });
            }
        }
    }
}
