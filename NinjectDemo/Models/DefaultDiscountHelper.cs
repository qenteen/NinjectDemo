using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectDemo.Models
{
    public class DefaultDiscountHelper : IDiscountHelper
    {
        private decimal _discount;

        public DefaultDiscountHelper(decimal discount)
        {
            _discount = discount;
        }
        public decimal ApplyDiscount(decimal price)
        {
            return (price - (_discount / 100m * price));
        }
    }
}