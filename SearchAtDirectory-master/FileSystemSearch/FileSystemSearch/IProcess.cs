using FileSystemSearch.DBWriter;
using FileSystemSearch.FileWrapper;
using FileSystemSearch.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch
{
    public interface IProcess
    {
        void ProcessFile(string filePath, IFileWrapper _fileWrapper, IDBWriter _dbWorker, EntityType type);
    }
}
