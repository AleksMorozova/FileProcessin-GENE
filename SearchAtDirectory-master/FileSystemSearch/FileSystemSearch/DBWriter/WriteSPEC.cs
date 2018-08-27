using System;
using FileSystemSearch.DAL;
using FileSystemSearch.Model;
using FileSystemSearch.Tools;

namespace FileSystemSearch.DBWriter
{
    public class WriteSPEC: IDBWriter
    {
        public void WriteToDB(string path, EntityType type)
        {
            using (var ctx = new StatisticContext())
            {
                var test = new ClientTest() { Name = path, CreationDate = DateTime.Now, Type = type };
                ctx.ClientTests.Add(test);
                ctx.SaveChanges();
            }
        }
    }
}
