
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using FileSystemSearch.DAL;
using FileSystemSearch.Model;
using FileSystemSearch.Tools;
using FileSystemSearch.ConcreteProcessors;
using FileSystemSearch.DBWriter;
using FileSystemSearch.FileWrapper;

namespace FileSystemSearch
{
    class Program
    {
        public static List<string> ExistingSelectors { get; set; }
        public static List<string> ExistingTests { get; set; }

        public static string TestResultFilePath { get; set; }
        public static string SelectorResultFilePath { get; set; }

        public static string MainPath { get; set; }
        static void Main(string[] args)
        {
            TestResultFilePath = @"D:\testResult.txt";
            SelectorResultFilePath = @"D:\selectorResult.txt";

            MainPath = @"J:\client\web-oe\web-client\modules\";

            File.WriteAllText(TestResultFilePath, String.Empty);
            File.WriteAllText(SelectorResultFilePath, String.Empty);

            ExistingSelectors = new List<string>();
            initSelectors();

            ProcessRequisitionTest(MainPath + PathConstants.requisitionTestPath);
            ProcessPatientTest(MainPath + PathConstants.patientTestPath);
            ProcessPatientSelectors(MainPath + PathConstants.patientModulePath);
            ProcessRequisitionSelectors(MainPath + PathConstants.requisitionModulePath);

            Console.ReadKey();
        }
        public static void initSelectors()
        {
            using (var ctx = new StatisticContext())
            {
                ExistingSelectors = ctx.Selectors.Select(_=>_.SelectorName).ToList();
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

        public static void ProcessRequisitionTest(string path)
        {
            var spec_processor = new DirectoryProcessor(new ProcessSPEC(), new FileWriter(), new WriteSPEC(), EntityType.requisitionIntegrationTest);
            spec_processor.Process(path);
            Console.WriteLine("End of processing requisition tests");
        }

        public static void ProcessPatientTest(string path)
        {
            var spec_processor = new DirectoryProcessor(new ProcessSPEC(), new FileWriter(), new WriteSPEC(), EntityType.patientIntegrationTest);
            spec_processor.Process(path);
            Console.WriteLine("End of processing patient tests");
        }

        public static void ProcessPatientSelectors(string path)
        {
            var spec_processor = new DirectoryProcessor(new ProcessSelector(), new FileWriter(), new WriteSelector(), EntityType.patientSelector);
            spec_processor.Process(path);
            Console.WriteLine("End of processing patient selectors");
        }

        public static void ProcessRequisitionSelectors(string path)
        {
            var spec_processor = new DirectoryProcessor(new ProcessSelector(), new FileWriter(), new WriteSelector(), EntityType.requisitionSelector);
            spec_processor.Process(path);
            Console.WriteLine("End of processing requisition selectors");
        }
    }
}

