using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjectDemo.Models;

namespace NinjectDemo.Models
{
    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal price)
        {
            if (price < 0) throw new ArgumentOutOfRangeException();
            if (price > 100) return price * 0.9M;
            if (price >= 10 && price <= 100) return price - 5;
            return price;
        }
    }
}