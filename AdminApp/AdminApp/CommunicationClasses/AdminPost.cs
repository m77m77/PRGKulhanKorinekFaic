﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.CommunicationClasses
{
    public class AdminPost : IData
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
