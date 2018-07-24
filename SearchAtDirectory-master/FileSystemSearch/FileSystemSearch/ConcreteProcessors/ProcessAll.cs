using FileSystemSearch.FileWrapper;
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
        public void ProcessFile(string path, IFileWrapper fileWrapper)
        {
            fileWrapper.WriteToFile(path, Program.ResultFilePath);
        }
    }
}
