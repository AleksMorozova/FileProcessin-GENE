﻿using System;
using System.ComponentModel.DataAnnotations;


namespace FileSystemSearch.Model
{
    public class SagaAction
    {
        [Key]
        public int ID { get; set; }
        public String SagaName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public String Path { get; set; }
        public String Author { get; set; }
        public String Task { get; set; }
    }
}
