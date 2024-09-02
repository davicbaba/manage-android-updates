using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAndroidUpdates.Components.Model
{
    internal class DeviceUpdate
    {

        public string Url { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public bool Downloaded { get; set; }
        public bool Installed { get; set; }

    }
}
