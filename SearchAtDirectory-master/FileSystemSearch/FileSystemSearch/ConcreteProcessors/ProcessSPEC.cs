﻿using System;
using FileSystemSearch.FileWrapper;
using System.IO;
using FileSystemSearch.DBWriter;
using FileSystemSearch.Tools;

namespace FileSystemSearch.ConcreteProcessors
{
    class ProcessSPEC : IProcess
    {
        public void ProcessFile(string path, IFileWrapper fileWrapper, IDBWriter dbWriter, EntityType type)
        {
            if (Path.GetFileNameWithoutExtension(path).ToString().Contains("spec"))
            {
                fileWrapper.WriteData(path, Program.TestResultFilePath);
                dbWriter.WriteToDB(Path.GetFileName(Path.GetDirectoryName(path)), type);
            }
        }
    }
}