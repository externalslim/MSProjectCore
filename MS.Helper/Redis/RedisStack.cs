using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.Data.Redis
{
    public class RedisStack
    {
        internal static Lazy<ConnectionMultiplexer> LazyConnection;
        private static Helper.Configuration.ConfigurationProvider ConfigurationProvider = null;
        static RedisStack()
        {
            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(ConfigurationOption));
            ConfigurationProvider = Helper.Configuration.ConfigurationProvider.Instance;
        }

        internal static ConfigurationOptions ConfigurationOption
        {
            get
            {
                var configurationOptions = new ConfigurationOptions();
                //if (!string.IsNullOrEmpty(ConfigurationProvider.RedisConnection.Host))
                    configurationOptions.EndPoints.Add(ConfigurationProvider.RedisConnection.Host, Convert.ToInt32(ConfigurationProvider.RedisConnection.Port));
                //if (!string.IsNullOrEmpty(ConfigMSO.RedisSlaveHost))
                //    configurationOptions.EndPoints.Add(ConfigMSO.RedisSlaveHost, Convert.ToInt32(ConfigMSO.RedisPort));
                configurationOptions.Password = "";
                configurationOptions.AbortOnConnectFail = false;
                configurationOptions.ResponseTimeout = 100000;
                configurationOptions.ConnectTimeout = 100000;
                configurationOptions.ConnectTimeout = 100000;
                configurationOptions.SyncTimeout = 100000;
                return configurationOptions;
            }
        }

        public static ConnectionMultiplexer Connection
        {
            get { return LazyConnection.Value; }
        }

        internal static IServer Server
        {
            get
            {
                var endpoints = Connection.GetEndPoints();
                var connectedEndPoints = endpoints.Where(x => Connection.GetServer(x).IsConnected);
                if (connectedEndPoints.Count() > 1)
                {
                    var slave = connectedEndPoints.First(endpoint => Connection.GetServer(endpoint).IsSlave);
                    return Connection.GetServer(slave);
                }
                return Connection.GetServer(connectedEndPoints.FirstOrDefault());
            }
        }

        public static IDatabase Database
        {
            get
            {
                return Connection.GetDatabase();
            }
        }
    }
}
