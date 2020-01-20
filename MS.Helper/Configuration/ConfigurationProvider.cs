using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MS.Helper.Configuration
{
    public class ConfigurationProvider
    {
        protected static object LockObject = new object();
        private static ConfigurationProvider _instance = null;
        private SystemConfigs SystemConfigs { get; set; }

        public static ConfigurationProvider Instance
        {
            get
            {
                if (_instance == null)
                    lock (LockObject)
                        if (_instance == null)
                            _instance = new ConfigurationProvider();
                return _instance;
            }
        }

        public void Load()
        {
            var m = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            var filePath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            //filePath = string.Join("\\", filePath,"bin", ConstEnumHelper.ConfigFolderName, $"{environment}.json"); 
            var fileStream = new FileStream(m, FileMode.Open, FileAccess.Read);
            using (var reader = new StreamReader(fileStream, Encoding.UTF8))
            {
                var systemConfigStr = reader.ReadToEnd();
                fileStream.Close();
                reader.Close();
                SystemConfigs = JsonConvert.DeserializeObject<SystemConfigs>(systemConfigStr);
            }
        }

        public JsonWebToken JsonWebToken => SystemConfigs.JsonWebToken;
        public RedisConnection RedisConnection => SystemConfigs.RedisConnection;
    }
}
