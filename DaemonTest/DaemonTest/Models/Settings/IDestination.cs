﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaemonTest.Models.Settings
{
    public interface IDestination
    {
        string Path { get; set; }
        string Type { get; set; }
    }
}