﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prode.Api.Auth
{
    public class TokenRequest
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
