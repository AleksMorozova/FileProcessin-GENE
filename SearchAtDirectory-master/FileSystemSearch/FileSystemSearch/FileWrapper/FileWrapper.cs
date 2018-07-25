
using System.IO;


namespace FileSystemSearch.FileWrapper
{
    public class FileWrapper : WorkWithFile, IFileWrapper
    {
        public void WriteToFile(string path, string resultFile)
        {
            using (StreamWriter sw = File.AppendText(resultFile))
            {
                sw.WriteLine(path);
            }
        }
    }
}
