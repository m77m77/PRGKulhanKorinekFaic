using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.Models.Settings
{
    public class Settings
    {
        [JsonProperty]
        public string DataType { get; set; }
        [JsonProperty]
        public string TypeOfBackup { get; set; }
        [JsonProperty]
        public string BeforeBackup { get; set; }
        [JsonProperty]
        public string AfterBackup { get; set; }
        [JsonProperty]
        public bool Comprimation { get; set; }

        public FTPDestination FTPDestination { get; set; }
        public Frequency Frequency { get; set; }
        public LocalDestination LocalDestination { get; set; }

        public IDestination Destination { get; set; }

        //public string Error { get; set; }

}
}