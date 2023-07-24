﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliopolis.Entities
{
    public class Book
    {
        [Key] public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Editorial { get; set; }
        public string Units { get; set; }
    }
}
