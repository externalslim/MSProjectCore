using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Configuration
{
    public class RedisConnection
    {
        public string Host { get; set; }
        public string SlaveHost { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }
}
