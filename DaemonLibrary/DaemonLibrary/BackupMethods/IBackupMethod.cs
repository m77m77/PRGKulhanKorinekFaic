using DaemonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonLibrary.BackupMethods
{
    public interface IBackupMethod
    {
        BackupStatus Backup();
    }
}
