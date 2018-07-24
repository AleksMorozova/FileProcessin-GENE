using FileSystemSearch.FileWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch
{
    public interface IProcess
    {
        void ProcessFile(string filePath, IFileWrapper _fileWrapper);
    }
}
