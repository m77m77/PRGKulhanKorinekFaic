using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    public class ListSettingsData : IData
    {
        public List<Settings> ListSettings { get; set; }
        public Settings DefaultSettings { get; set; }
    }
}
