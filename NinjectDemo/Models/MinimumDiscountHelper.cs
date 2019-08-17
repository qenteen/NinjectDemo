using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjectDemo.Models;

namespace NinjectDemo.Models
{
    public class MinimumDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (10m / 100m * totalParam));
        }
    }
}