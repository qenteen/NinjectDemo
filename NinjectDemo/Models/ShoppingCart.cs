using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectDemo.Models
{
    public class ShoppingCart
    {
        private LinqValueCalculator _calc;
        public IEnumerable<Product> Products { get; set; }

        public ShoppingCart(LinqValueCalculator calculator)
        {
            _calc = calculator;
        }

        public decimal CalculateProductTotal()
        {
            return _calc.ValueProducts(Products);
        }
    }
}