using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.Models.Settings
{
    public interface ISettings
    {
        int SettingsID { get; set; }
        BackupScheme BackupScheme { get; set; }
        List<IDestination> Destinations { get; set; }
    }
}
