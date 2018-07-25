
using System.IO;


namespace FileSystemSearch.FileWrapper
{
    public abstract class WorkWithFile
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
