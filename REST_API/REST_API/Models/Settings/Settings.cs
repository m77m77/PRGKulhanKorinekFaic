using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class Settings
    {
        public string DataType { get; set; }
        public string TypeOfBackup { get; set; }
        public string BeforeBackup { get; set; }
        public string AfterBackup { get; set; }
        public bool Comprimation { get; set; }

        public IDestination Destination { get; set; }


        public string Error { get; set; }

        public Settings(string DataType, string TypeOfBackup, string BeforeBackup, string AfterBackup, bool Comprimation, string Error)
        {
            this.AfterBackup = AfterBackup;
            this.BeforeBackup = BeforeBackup;
            this.Comprimation = Comprimation;
            this.DataType = DataType;
            this.TypeOfBackup = TypeOfBackup;
            this.Error = Error;

        }
    }
}