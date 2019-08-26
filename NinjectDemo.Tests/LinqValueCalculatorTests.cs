using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjectDemo.Models;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NinjectDemo.Tests
{
    [TestClass]
    public class LinqValueCalculatorTests
    {
        private Product[] products =
        {
            new Product { Name = "Kayak", Price = 350M },
            new Product { Name = "Lifejacket", Price = 100M },
            new Product { Name = "Soccer ball", Price = 25.5M },
            new Product { Name = "Corner flag", Price = 24.5M }
        };

        [TestMethod]
        public void ValueProducts_TotalPrice500_Return500()
        {
            var mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(price => price);

            var calc = new LinqValueCalculator(mock.Object);

            Assert.AreEqual(500, calc.ValueProducts(products));
        }

        private Product[] GetProducts(decimal price)
        {
            return new[] { new Product() { Name = "Kayak", Price = price } };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValueProducts_WorksWithMinimumDiscountHelper()
        {
            // Arrange
            var mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(p => p < 0)))
                .Throws<ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(0, 9, Range.Inclusive)))
                .Returns<decimal>(p => p);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
                .Returns<decimal>(p => p - 5);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(p => p > 100)))
                .Returns<decimal>(p => p * 0.9M);

            var calc = new LinqValueCalculator(mock.Object);

            // Act
            var discounted200Dol = calc.ValueProducts(GetProducts(200));
            var discounted100Dol = calc.ValueProducts(GetProducts(100));
            var discounted50Dol = calc.ValueProducts(GetProducts(50));
            var discounted10Dol = calc.ValueProducts(GetProducts(10));
            var discounted7Dol = calc.ValueProducts(GetProducts(7));
            var discounted0Dol = calc.ValueProducts(GetProducts(0));

            // Assert
            Assert.AreEqual(180, discounted200Dol, "$200 wrong");
            Assert.AreEqual(95, discounted100Dol, "$100 wrong");
            Assert.AreEqual(45, discounted50Dol, "$50 wrong");
            Assert.AreEqual(5, discounted10Dol, "$10 wrong");
            Assert.AreEqual(7, discounted7Dol, "$7 wrong");
            Assert.AreEqual(0, discounted0Dol, "$0 wrong");
            calc.ValueProducts(GetProducts(-5));
        }
    }
}
