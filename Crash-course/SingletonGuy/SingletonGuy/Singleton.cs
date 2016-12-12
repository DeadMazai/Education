using System;
using System.Collections.Generic;

namespace SingletonGuy
{
    public class Singleton
    {
        private static Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());
        private readonly Dictionary<string, string> configuration;

        private Singleton()
        {
            this.configuration = new Dictionary<string, string>();
        }

        public static Singleton GetInstance
        {
            get { return instance.Value; }
        }

        public string GetConfigValue(string key)
        {
            return configuration[key];
        }

        public void SetConfigValue(string key, string value)
        {
            configuration[key] = value;
        }
    }
}
