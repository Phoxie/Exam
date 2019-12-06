using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IDataInterface
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CustomerID { get; set; }

        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }

        public string CustomerBirthday { get; set; }
        public bool Deleted { get; set; }
    }
}
