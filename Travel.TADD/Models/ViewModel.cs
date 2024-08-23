using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel.TADD.Models
{
    public class ViewModel
    {
        public String NamePro { get; set; }
        public String ImgPro { get; set; }
        public decimal pricePro { get; set; }
        public String NameCate { get; set; }
        public String DesPro { get; set; }
        [System.ComponentModel.DataAnnotations.Key]
        public int? IDPro { get; set; }
        public decimal Total_Money { get; set; }
        public Product product { get; set; }
        public Category category { get; set; }
        public OrderDetail orderDetail { get; set; }
        public IEnumerable<Product> ListProduct { get; set; }
        public int? Top5_Quantity { get; set; }
        public int? Sum_Quantity { get; set; }
    }
}