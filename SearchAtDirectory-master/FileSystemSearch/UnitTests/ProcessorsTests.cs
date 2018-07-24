using FileSystemSearch.ConcreteProcessors;
using FileSystemSearch.FileWrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemWrapper.IO;

namespace UnitTests
{
    [TestClass]
    public class ProcessorsTests
    {

        [TestMethod]
        public void TestProccessReversed2()
        {
            ProcessReversed2 proc = new ProcessReversed2();
            List<string> returnedString = new List<string>();

            Mock<IFileWrapper> mockadd = new Mock<IFileWrapper>();
      
            mockadd.Setup(x => x.WriteToFile(It.IsAny<string>(),
                It.IsAny<string>())).Callback((string a, string b)
                => { returnedString.Add(a);});

            proc.ProcessFile(@"D:\abc\df.txt", mockadd.Object);

            Assert.IsTrue(returnedString.Contains(@"txt.fd\cba\:D"));
        }
        [TestMethod]
        public void TestProcessorsCPP()
        {
            ProcessCPP proc = new ProcessCPP();
            List<string> returnedString = new List<string>();

            Mock<IFileWrapper> mockadd = new Mock<IFileWrapper>();

            mockadd.Setup(x => x.WriteToFile(It.IsAny<string>(),
                It.IsAny<string>())).Callback((string a, string b)
                => { returnedString.Add(a); });

            proc.ProcessFile(@"D:\abc\df.txt", mockadd.Object);

            Assert.IsTrue(returnedString.Count()==0);
        }

        [TestMethod]
        public void TestProcessorsAll()
        {
            ProcessAll proc = new ProcessAll();
            List<string> returnedString = new List<string>();

            Mock<IFileWrapper> mockadd = new Mock<IFileWrapper>();

            mockadd.Setup(x => x.WriteToFile(It.IsAny<string>(),
                It.IsAny<string>())).Callback((string a, string b)
                => { returnedString.Add(a); });

            proc.ProcessFile(@"D:\abc\df.txt", mockadd.Object);

            Assert.IsTrue(returnedString.Contains(@"D:\abc\df.txt"));
        }

        [TestMethod]
        public void TestProccessReversed1()
        {
            ProcessReversed1 proc = new ProcessReversed1();
            List<string> returnedString = new List<string>();

            Mock<IFileWrapper> mockadd = new Mock<IFileWrapper>();
  
            mockadd.Setup(x => x.WriteToFile(It.IsAny<string>(),
                It.IsAny<string>())).Callback((string a, string b)
                => { returnedString.Add(a); });

            proc.ProcessFile(@"D:\abc\df.txt", mockadd.Object);

            Assert.IsTrue(returnedString.Contains(@":D\cba\txt.fd"));
        }
    }
}
