using System;
using FileSystemSearch.FileWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch.ConcreteProcessors
{
    class ProcessSPEC : IProcess
    {
        public void ProcessFile(string path, IFileWrapper fileWrapper)
        {
            if (Path.GetFileNameWithoutExtension(path).ToString().Contains("spec"))
                fileWrapper.WriteToFile(path, Program.ResultFilePath);
        }
    }
}
