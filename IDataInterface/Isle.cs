using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDataInterface
{
    public class Isle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IsleID { get; set; }

        public int IsleNumber { get; set; }

        public bool Deleted { get; set; }

        public ICollection<Shelf> Shelves { get; set; }
        
    }
}
