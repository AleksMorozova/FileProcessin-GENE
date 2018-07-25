
using FileSystemSearch.FileWrapper;
using System.IO;

namespace FileSystemSearch.ConcreteProcessors
{
    class ProcessSelector : IProcess
    {
        public void ProcessFile(string path, IFileWrapper fileWrapper)
        {
            if (Path.GetFileNameWithoutExtension(path).ToString().Contains("selector"))
                fileWrapper.WriteToFile(path, Program.ResultFilePath);
        }
    }
}
