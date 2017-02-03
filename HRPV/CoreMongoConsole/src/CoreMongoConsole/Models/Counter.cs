namespace CoreMongoConsole
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Counter
    {
        [BsonElement("_id")]
        public string ID
        {
            get;
            set;
        }

        [BsonElement("sequence_value")]
        public int LastIdentifier
        {
            get;
            set;
        }
    }
}
