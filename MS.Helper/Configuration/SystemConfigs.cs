using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Configuration
{
    public class SystemConfigs
    {
        public JsonWebToken JsonWebToken { get; set; }
        public RedisConnection RedisConnection { get; set; }

        public SystemConfigs()
        {
            JsonWebToken = new JsonWebToken();
            RedisConnection = new RedisConnection();
        }
    }
}
