﻿using System;
using System.Collections.Generic;
using System.Text;

namespace REST_API.Models.BackupStatus
{
    public class BackupError
    {
        public string Path { get; set; }
        public string Message { get; set; }
    }
}
