using FileSystemSearch.FileWrapper;
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

        public DirectoryProcessor(IProcess processor, IFileWrapper fileWrapper)
        {
            _processor = processor;
            _fileWrapper = fileWrapper;
        }

        public void Process(string path)
        {
            if (_fileWrapper.Exists(path))
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
                _processor.ProcessFile(fileName, _fileWrapper);

            string[] subdirectoryEntries = Directory.GetDirectories(path);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
    }
}
