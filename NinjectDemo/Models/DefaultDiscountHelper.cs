using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectDemo.Models
{
    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (10m / 100m * totalParam));
        }
    }
}