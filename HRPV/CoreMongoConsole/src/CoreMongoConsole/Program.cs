namespace CoreMongoConsole
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class Program
    {
        public static void Main(string[] args)
        {
            
            var t = new MongoClient(@"mongodb://localhost:27017");
            var db = t.GetDatabase("local");
            var idProvider = new IdentifierProvider(db);
            Console.WriteLine(db.Settings.ToString());

         /*   var startup_log = db.GetCollection<SturtupLog>("startup_log");
            var logs = startup_log.Find(new BsonDocument()).ToList();
            logs.ForEach(x => Console.WriteLine(string.Format("{0} - {1} - {2} - {3}", x.ID, x.Hostname,x.Pid,x.StartTime)));*/


            var consoleDataCollection = db.GetCollection<ConsoleData>("console_data");
            consoleDataCollection.Find(new BsonDocument()).ToList().ForEach(WriteConsoleData);

            Console.Write("Insert integer: ");
            var testField = int.Parse(Console.ReadLine());
            var dateTime = DateTime.Now;
            var id = idProvider.GetNextIdentifer("console_data");

            consoleDataCollection.InsertOneAsync(new ConsoleData
            {
                TestField = testField,
                DateTime= dateTime,
                ID = id
            });

            consoleDataCollection.Find(new BsonDocument()).ToList().ForEach(WriteConsoleData);

            Console.ReadLine();
        }

        private static void WriteConsoleData(ConsoleData consoleData)
        {
            Console.WriteLine(
                    string.Format(
                        "{0} - {1} - {2}",
                        consoleData.ID,
                        consoleData.TestField,
                        consoleData.DateTime != DateTime.MinValue ? consoleData.DateTime.ToString("yyyy-MM-dd HH:mm:ss") : "NO DATE"));
        }
    }
}
