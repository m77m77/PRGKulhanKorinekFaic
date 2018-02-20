using DaemonTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaemonTest.BackupMethods
{
    public interface IBackupMethod
    {
        BackupStatus Backup();
    }
}
