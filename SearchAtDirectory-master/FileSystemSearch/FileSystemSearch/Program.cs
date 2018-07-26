
using System;
using FileSystemSearch.FileWrapper;


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
            var spec_processor = new DirectoryProcessor(new ConcreteProcessors.ProcessSPEC(), new FileWrapper.FileWrapper());
            spec_processor.Process(StartFolder);
            Console.WriteLine("End of processing spec files");


            /*Registration.Registrate<FileWrapper.WriteToDB>(ActionType.spec);
            var spec_processor = new DirectoryProcessor(Registration.processor, Registration.fileWrapper);
            spec_processor.Process(StartFolder);
            Console.WriteLine("End of processing spec files");

            ResultFilePath = @"D:\result.txt";
            StartFolder = @"D:\Main";
            Registration.Registrate<FileWrapper.WriteToDB>(ActionType.selector);
            var selector_processor = new DirectoryProcessor(Registration.processor, Registration.fileWrapper);
            selector_processor.Process(StartFolder);
            Console.WriteLine("End of processing selectors files");*/
            Console.ReadKey();
        }
    }
}
