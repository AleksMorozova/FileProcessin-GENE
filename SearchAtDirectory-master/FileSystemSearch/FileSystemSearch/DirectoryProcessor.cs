using FileSystemSearch.DBWriter;
using FileSystemSearch.FileWrapper;
using FileSystemSearch.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FileSystemSearch
{
    public class DirectoryProcessor
    {
        private IProcess _processor;
        private IFileWrapper _fileWrapper;
        private IDBWriter _dbWriter;
        private EntityType _type;
        private WorkWithFile fileWorker = new WorkWithFile();

        public DirectoryProcessor(IProcess processor, IFileWrapper fileWrapper, IDBWriter dbWriter, EntityType type)
        {
            _processor = processor;
            _fileWrapper = fileWrapper;
            _dbWriter = dbWriter;
            _type = type;
        }

        public void Process(string path)
        {
            if (fileWorker.Exists(path))
            {
                ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }

        }

        public void ProcessDirectory(string path)
        {
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
                _processor.ProcessFile(fileName, _fileWrapper, _dbWriter, _type);

            string[] subdirectoryEntries = Directory.GetDirectories(path);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
    }
}
