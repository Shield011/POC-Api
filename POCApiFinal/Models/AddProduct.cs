using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCApiFinal.Models
{
    public class AddProduct
    {
        public int productId { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}
