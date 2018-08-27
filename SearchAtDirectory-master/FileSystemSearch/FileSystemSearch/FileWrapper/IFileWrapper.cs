using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch.FileWrapper
{
    public interface IFileWrapper
    {
        void WriteData(string path, string resultFile);
    }
}
