namespace CoreMongoConsole
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class ConsoleData
    {
        [BsonElement("_id")]
        public int ID
        {
            get;
            set;
        }

        [BsonElement("testField")]
        public int TestField
        {
            get;
            set;
        }

        [BsonElement("dateTime")]
        public DateTime DateTime
        {
            get;
            set;
        }
    }
}
