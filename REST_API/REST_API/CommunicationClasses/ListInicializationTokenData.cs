﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_API.CommunicationClasses
{
    public class ListInicializationTokenData : IData
    {
        public List<InicializationToken> ListInicializationToken { get; set; }
    }
}