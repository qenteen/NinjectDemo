using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NinjectDemo.Models;

namespace NinjectDemo.Tests
{
    [TestClass]
    public class MinimumDiscountHelperTests
    {
        private IDiscountHelper GetTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void ApplyDiscount_PriceAbove100_Discount10Perc()
        {
            // Assert
            IDiscountHelper discountHelper = GetTestObject();
            decimal price = 200;

            // Act
            var discountedPrice = discountHelper.ApplyDiscount(price);

            // Assert
            Assert.AreEqual(180, discountedPrice);
        }

        [TestMethod]
        public void ApplyDiscount_PriceBetween10And100_FixedDiscount5Bucks()
        {
            IDiscountHelper discountHelper = GetTestObject();
            
            var discountFor10 = discountHelper.ApplyDiscount(10);
            var discountFor50 = discountHelper.ApplyDiscount(50);
            var discountFor100 = discountHelper.ApplyDiscount(100);

            Assert.AreEqual(5, discountFor10, "Discount for $10 is wrong");
            Assert.AreEqual(45, discountFor50, "Discount for $50 is wrong");
            Assert.AreEqual(95, discountFor100, "Discount for $100 is wrong");
        }

        [TestMethod]
        public void ApplyDiscount_PriceBelow10_NoDiscount()
        {
            IDiscountHelper discountHelper = GetTestObject();

            var DiscountFor7 = discountHelper.ApplyDiscount(7);
            var DiscountFor0 = discountHelper.ApplyDiscount(0);

            Assert.AreEqual(7, DiscountFor7, "Discount for $7 is wrong");
            Assert.AreEqual(0, DiscountFor0, "Discount for $0 is wrong");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ApplyDiscount_NegativePrice_ArgumentOutOfRangeException()
        {
            IDiscountHelper discountHelper = GetTestObject();

            var discountForNegative100 = discountHelper.ApplyDiscount(-100);
        }
    }
}
