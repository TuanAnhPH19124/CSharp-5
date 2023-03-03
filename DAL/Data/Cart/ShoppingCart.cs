using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Cart
{
    public class ShoppingCart
    {
        public static IEnumerable<GioHang> gioHangs { get; set; }
    }
}
