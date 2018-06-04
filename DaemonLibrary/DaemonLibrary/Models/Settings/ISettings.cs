using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonLibrary.Models.Settings
{
    public interface ISettings
    {
        int SettingsID { get; set; }
        BackupScheme BackupScheme { get; set; }
        List<IDestination> Destinations { get; set; }
        string ActionAfterBackup { get; set; }
        string ActionBeforeBackup { get; set; }
    }
}
