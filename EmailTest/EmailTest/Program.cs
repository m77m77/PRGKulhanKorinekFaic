﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SendEmail se = new SendEmail();
            se.SendingEmail();
            Console.ReadLine();
        }
    }
}
