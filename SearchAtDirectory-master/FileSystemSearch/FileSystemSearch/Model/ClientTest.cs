using FileSystemSearch.Tools;
using System;
using System.ComponentModel.DataAnnotations;


namespace FileSystemSearch.Model
{
    public class ClientTest
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public EntityType Type { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
