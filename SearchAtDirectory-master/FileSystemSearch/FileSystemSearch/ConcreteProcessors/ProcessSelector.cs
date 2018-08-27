﻿
using FileSystemSearch.DBWriter;
using FileSystemSearch.FileWrapper;
using FileSystemSearch.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace FileSystemSearch.ConcreteProcessors
{
    class ProcessSelector : IProcess
    {  
        private List<string> getAllSelectors(string path)
        {
            List<string> result = new List<string>();
            StreamReader reader = File.OpenText(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("createSelector") && !line.Contains("import"))
                {
                    string addedLin = line.Replace("export const ", "");
                    List<int> spaces = new List<int>();
                    string pattern = @"=";

                    Regex expr = new Regex(pattern);
                    MatchCollection matches = expr.Matches(addedLin);

                    foreach (Match match in matches)
                    {
                        spaces.Add(match.Index);
                    }

                    int start = spaces[0] - 1;
                    Console.WriteLine(start);
                    result.Add(addedLin.Substring(0, start));
                }
            }
            return result;
        }

        public void ProcessFile(string path, IFileWrapper fileWrapper, IDBWriter dbWriter, EntityType type)
        {
            if (Path.GetFileNameWithoutExtension(path).ToString().Contains("selectors"))
            {
                List<string> result = getAllSelectors(path);

                foreach (string selector in result)
                {
                    if (!Program.ExistingSelectors.Contains(selector))
                    {
                        fileWrapper.WriteData(selector, Program.SelectorResultFilePath);
                        dbWriter.WriteToDB(selector, type);
                    }
                }
            }
        }
    }
}
