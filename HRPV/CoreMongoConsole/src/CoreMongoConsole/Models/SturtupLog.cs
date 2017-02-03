namespace CoreMongoConsole
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class SturtupLog
    {
        [BsonElement("_id")]
        public string ID
        {
            get;
            set;
        }

        [BsonElement("hostname")]
        public string Hostname
        {
            get;
            set;
        }

        [BsonElement("startTime")]
        public DateTime StartTime
        {
            get;
            set;
        }

        [BsonElement("pid")]
        public int Pid { get; set; }
    }
}
