
using System;
using FileSystemSearch.FileWrapper;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using FileSystemSearch.DAL;
using FileSystemSearch.Model;

namespace FileSystemSearch
{
    class Program
    {
        public static List<Selector> ExistingSelectors { get; set; } // = new List<Selector>();

        public static string ResultFilePath { get; set; }
        public static string StartFolder { get; set; }
        static void Main(string[] args)
        {
            ResultFilePath = @"D:\result.txt";
            File.WriteAllText(ResultFilePath, String.Empty);
            ExistingSelectors = new List<Selector>();
            initSelectors();

            StartFolder = @"D:\Main";
            var spec_processor = new DirectoryProcessor(new ConcreteProcessors.ProcessSPEC(), new FileWrapper.FileWrapper());
            spec_processor.Process(StartFolder);
            Console.WriteLine("End of processing spec files");

            Console.ReadKey();
        }
        public static void initSelectors()
        {
            using (var ctx = new StatisticContext())
            {
                ExistingSelectors = ctx.Selectors.ToList();
            }
        }
        public static void WriteFirstSelector()
        {
            List<string> result = new List<string>();
            StreamReader reader = File.OpenText(@"D:\selector.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                result.Add(line);
            }

            using (var ctx = new StatisticContext())
            {
                foreach (var s in result)
                {
                    var selector = new Selector() { SelectorName = s, AddedDate = DateTime.Now };
                    ctx.Selectors.Add(selector);
                    ctx.SaveChanges();
                }
            }
        }
    }
}

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
