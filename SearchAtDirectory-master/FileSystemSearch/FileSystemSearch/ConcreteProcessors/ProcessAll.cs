using FileSystemSearch.DBWriter;
using FileSystemSearch.FileWrapper;
using FileSystemSearch.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch.ConcreteProcessors
{
    public class ProcessAll : IProcess
    {
        public void ProcessFile(string path, IFileWrapper fileWrapper, IDBWriter dbWriter, EntityType type)
        {
            fileWrapper.WriteData(path, Program.TestResultFilePath);
        }
    }
}
