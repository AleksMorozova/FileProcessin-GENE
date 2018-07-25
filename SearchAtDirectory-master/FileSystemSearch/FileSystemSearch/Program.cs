
using System;


namespace FileSystemSearch
{
    class Program
    {
        public static string ResultFilePath { get; set; }
        public static string StartFolder { get; set; }
        static void Main(string[] args)
        {
            ResultFilePath = @"D:\result.txt";
            StartFolder = @"D:\Main";
            Registration.Registrate<FileWrapper.WriteToDB>(ActionType.spec);
            var processor = new DirectoryProcessor(Registration.processor, Registration.fileWrapper);
            processor.Process(StartFolder);
            Console.WriteLine("End directory processing");
            Console.ReadKey();
        }
    }
}
