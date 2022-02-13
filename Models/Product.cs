using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMauiBlazorLoginJwt.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
