using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POCApiFinal.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ProductName { get; set; }

       
        public int ProductCount{get; set;}

        [Column(TypeName = "nvarchar(5)")]
        public string InCart { get; set; }

       
        public int Price { get; set; }
    }
}
