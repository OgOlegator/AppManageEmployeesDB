using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DeeplayTestApp.DB
{
    public class JobTitleDirectory
    {
        public struct StrucJobTitle
        {
            public string Name;
            public int Level;
        }

        private List<StrucJobTitle> _directoryJobTitles;

        private employeesDataSetTableAdapters.JobTitle1TableAdapter _jobTitleTableAdapter 
            = new employeesDataSetTableAdapters.JobTitle1TableAdapter();

        public JobTitleDirectory()
        { }

        public List<StrucJobTitle> GetDirectoryJobTitle()
        {
            if (_directoryJobTitles == null)
                SetDirectoryJobTitles();

            return _directoryJobTitles;
        }


        public List<string> GetJobTitles()
            => GetDirectoryJobTitle().Select(x => x.Name).ToList();

        private void SetDirectoryJobTitles()
        {
            _directoryJobTitles = new List<StrucJobTitle>();

            var jobTitleDbData = _jobTitleTableAdapter.GetDataJobTitle();

            foreach (DataRow jobTitle in jobTitleDbData.Rows)
            {
                _directoryJobTitles.Add(new StrucJobTitle { Name = jobTitle.ItemArray[0].ToString(), Level = int.Parse(jobTitle.ItemArray[1].ToString()) });
            }
        }
    }
}
