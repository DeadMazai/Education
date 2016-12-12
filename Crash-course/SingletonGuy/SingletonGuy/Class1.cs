using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonGuy
{
    public class Singleton
    {
        private static Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());
        private Dictionary<string, string> configuration;

        private Singleton()
        {
            this.configuration = new Dictionary<string, string>();
        }

        public static Singleton GetInstance
        {
            get { return instance.Value; }
        }

        public string GetConfigValue()
        {
            
        }
    }
}
