using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NinjectDemo.Models;

namespace NinjectDemo.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator _calc;

        private Product[] products =
        {
            new Product { Name = "Kayak", Category = "Watersports", Price = 300M },
            new Product { Name = "Lifejacket", Category = "Watersports", Price = 150M },
            new Product { Name = "Soccer ball", Category = "Soccer", Price = 25.50M },
            new Product { Name = "Corner flag", Category = "Soccer", Price = 24.50M }
        };

        public HomeController(IValueCalculator calc)
        {
            _calc = calc;
        }

        // GET: Home
        public ActionResult Index()
        {
            //IDiscountHelper discounter = new DefaultDiscountHelper();
            //IValueCalculator calc = new LinqValueCalculator(discounter);
            var cart = new ShoppingCart(_calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();

            return View(totalValue);
        }
    }
}