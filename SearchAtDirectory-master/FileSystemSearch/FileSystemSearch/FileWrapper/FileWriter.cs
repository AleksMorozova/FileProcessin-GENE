
using System.IO;


namespace FileSystemSearch.FileWrapper
{
    public class FileWriter : IFileWrapper
    {
        public void WriteData(string path, string resultFile)
        {
            using (StreamWriter sw = File.AppendText(resultFile))
            {
                sw.WriteLine(path);
            }
        }
    }
}
