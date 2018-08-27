using System;
using FileSystemSearch.DAL;
using FileSystemSearch.Model;
using FileSystemSearch.Tools;

namespace FileSystemSearch.DBWriter
{
    class WriteSAGA : IDBWriter
    {
        public void WriteToDB(string path, EntityType type)
        {
            using (var ctx = new StatisticContext())
            {
                var saga = new SagaAction() { SagaName = path, AddedDate = DateTime.Now, Type = type };
                ctx.Sagas.Add(saga);
                ctx.SaveChanges();
            }
        }
    }
}
