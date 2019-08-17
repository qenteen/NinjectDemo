using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NinjectDemo.Models;

namespace NinjectDemo.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}