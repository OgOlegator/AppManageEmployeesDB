using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeplayTestApp
{
    public static class Constants
    {
        public const string Director = "Директор";
        public const string Supervisor = "Руководитель";
        public const string Controller = "Контролер";
        public const string Worker = "Рабочий";

        public const string ModeUpdate = "Update row";
        public const string ModeAdd = "Add row";

        public const string FilterAllValues = "Все";

        public enum Mode
        {
            Create,
            Change
        }
    }

}
