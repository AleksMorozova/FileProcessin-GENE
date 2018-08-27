using System;
using FileSystemSearch.DAL;
using FileSystemSearch.Model;
using FileSystemSearch.Tools;

namespace FileSystemSearch.DBWriter
{
    class WriteSelector : IDBWriter
    {
        public void WriteToDB(string path, EntityType type)
        {
            using (var ctx = new StatisticContext())
            {
                var selector = new Selector() { SelectorName = path, AddedDate = DateTime.Now, Type = type };
                ctx.Selectors.Add(selector);
                ctx.SaveChanges();
            }
        }
    }
}
