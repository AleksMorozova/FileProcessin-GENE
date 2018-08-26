using FileSystemSearch.Tools;
using System;
using System.ComponentModel.DataAnnotations;


namespace FileSystemSearch.Model
{
    class ClientTest
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public TestType Type { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
