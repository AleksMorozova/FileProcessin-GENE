using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch.FileWrapper
{
    public interface IFileWrapper
    {
        string[] GetDirectiry(string path);
        string[] GetFiles(string path);
        bool Exists(string path);
        void WriteToFile(string path, string resultFile);
    }
}
