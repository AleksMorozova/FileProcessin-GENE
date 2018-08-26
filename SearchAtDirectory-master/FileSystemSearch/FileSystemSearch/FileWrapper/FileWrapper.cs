
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
/* var fullPath = Path.GetFullPath(path);
FileSecurity fileSecurity = File.GetAccessControl(@"D:\Main\A\3.spec.txt");
IdentityReference sid = fileSecurity.GetOwner(typeof(SecurityIdentifier));
NTAccount ntAccount = sid.Translate(typeof(NTAccount)) as NTAccount;
string owner = ntAccount.Value;
var creation = File.GetCreationTime(path);
var modification = File.GetLastWriteTime(path);
String s = creation + "/ " + modification + "/" + path;
sw.WriteLine(s); */