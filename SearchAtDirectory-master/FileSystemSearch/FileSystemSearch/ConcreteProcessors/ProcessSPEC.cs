using System;
using FileSystemSearch.FileWrapper;
using System.IO;

namespace FileSystemSearch.ConcreteProcessors
{
    class ProcessSPEC : IProcess
    {
        public void ProcessFile(string path, IFileWrapper fileWrapper)
        {
            if (Path.GetFileNameWithoutExtension(path).ToString().Contains("spec"))
            {
                Console.WriteLine(Path.GetFileName(Path.GetDirectoryName(path)));
                fileWrapper.WriteToFile(path, Program.ResultFilePath);

            }
        }
    }
}
