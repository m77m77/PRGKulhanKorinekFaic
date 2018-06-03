﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaemonLibrary.Models.Settings
{
    public interface IDestination
    {
        string Path { get; set; }
        string Type { get; set; }
        string SaveFormat { get; set; }
    }
}