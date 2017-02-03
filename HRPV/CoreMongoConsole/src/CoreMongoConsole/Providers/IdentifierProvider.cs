using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMongoConsole
{
    using MongoDB.Driver;

    public class IdentifierProvider
    {
        private IMongoDatabase mongoDatabaseBase;

        public IdentifierProvider(IMongoDatabase mongoDatabaseBase)
        {
            this.mongoDatabaseBase = mongoDatabaseBase;
        }

        public int GetNextIdentifer(string collectionName)
        {
            var collection = this.mongoDatabaseBase.GetCollection<Counter>("counters");
            var counter = collection.FindOneAndUpdate<Counter>(
                c => c.ID == collectionName, 
                Builders<Counter>.Update.Inc(c => c.LastIdentifier, 1));
            //collection
            return counter.LastIdentifier;
        }
    }
}
