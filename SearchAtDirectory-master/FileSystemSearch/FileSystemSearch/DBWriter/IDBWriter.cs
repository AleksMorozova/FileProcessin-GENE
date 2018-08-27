using FileSystemSearch.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemSearch.DBWriter
{
    public interface IDBWriter
    {
        void WriteToDB(string data, EntityType type);
    }
}
