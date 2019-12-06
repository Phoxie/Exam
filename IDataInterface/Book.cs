using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

        public int BookNumber { get; set; }

        public string BookName { get; set; }
        public decimal BookPrice { get; set; }     
        
        public int ShelfID { get; set; }
        public bool Deleted { get; set; }
        public Shelf Shelf { get; set; }

    }
}
