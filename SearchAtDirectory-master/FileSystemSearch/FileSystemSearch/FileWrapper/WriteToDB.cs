using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemSearch.DAL;
using FileSystemSearch.Model;

namespace FileSystemSearch.FileWrapper
{
    class WriteToDB : WorkWithFile, IFileWrapper
    {
        public void WriteToFile(string path, string resultFile)
        {
            using (var ctx = new StatisticContext())
            {
                var selector = new Selector() { SelectorName = path, AddedDate = DateTime.Now };
                ctx.Selectors.Add(selector);
                ctx.SaveChanges();
            }
        }
    }
}
