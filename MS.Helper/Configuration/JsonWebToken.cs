using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Configuration
{
    public class JsonWebToken
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigningKey { get; set; }
        public string AllowedHosts { get; set; }
    }
}
