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
            using (StreamWriter sw = File.AppendText(resultFile))
            {
                var fullPath = Path.GetFullPath(path);
                FileSecurity fileSecurity = File.GetAccessControl(@"D:\Main\A\3.spec.txt");
                IdentityReference sid = fileSecurity.GetOwner(typeof(SecurityIdentifier));
                NTAccount ntAccount = sid.Translate(typeof(NTAccount)) as NTAccount;
                string owner = ntAccount.Value;
                var creation = File.GetCreationTime(path);
                var modification = File.GetLastWriteTime(path);
                String s = creation + "/ " + modification + "/" + path;
                sw.WriteLine(s);



                using (var ctx = new StatisticContext())
                {
                    var selector = new Selector() { SelectorName = s, AddedDate = DateTime.Now };
                    ctx.Selectors.Add(selector);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
