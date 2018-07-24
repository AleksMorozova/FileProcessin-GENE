using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch.FileWrapper
{
    abstract class WorkWithFile
    {
        public string[] GetDirectiry(string path)
        {
            return Directory.GetDirectories(path);
        }
        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
