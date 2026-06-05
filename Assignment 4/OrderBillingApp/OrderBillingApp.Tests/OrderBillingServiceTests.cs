using NUnit.Framework;
using System;
using OrderBillingApp.Services;

namespace OrderBillingApp.Tests
{
    [TestFixture]
    public class OrderBillingServiceTests
    {
        private OrderBillingService _orderBillingService;

        [SetUp]
        public void SetUp()
        {
            _orderBillingService = new OrderBillingService();
        }

        [TestCase(1000, 5, 5000)]
        [TestCase(500, 4, 2000)]
        [TestCase(200, 10, 2000)]
        public void When_CalculateSubTotal_ValidInput_ReturnsSubTotal(
            decimal productPrice,
            int quantity,
            decimal expectedSubTotal)
        {
            decimal subTotal =
                _orderBillingService.CalculateSubTotal(
                    productPrice,
                    quantity);

            Assert.That(subTotal,
                Is.EqualTo(expectedSubTotal));
        }

        [Test]
        public void When_CalculateSubTotal_ProductPriceZero_ThrowsArgumentException()
        {
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() =>
                _orderBillingService.CalculateSubTotal(0, 5));

            Assert.That(exception.Message,
                Is.EqualTo("Product price must be greater than zero."));
        }

        [Test]
        public void When_CalculateDiscount_SubTotalGreaterThan5000_Returns10Percent()
        {
            decimal discount =
                _orderBillingService.CalculateDiscount(5000);

            Assert.That(discount,
                Is.EqualTo(500));
        }

        [Test]
        public void When_CalculateDiscount_SubTotalBetween2000And4999_Returns5Percent()
        {
            decimal discount =
                _orderBillingService.CalculateDiscount(3000);

            Assert.That(discount,
                Is.EqualTo(150));
        }

        [Test]
        public void When_CalculateDiscount_SubTotalLessThan2000_ReturnsZero()
        {
            decimal discount =
                _orderBillingService.CalculateDiscount(1500);

            Assert.That(discount,
                Is.EqualTo(0));
        }

        [Test]
        public void When_CalculateDeliveryCharge_AmountLessThan1000_Returns100()
        {
            decimal deliveryCharge =
                _orderBillingService.CalculateDeliveryCharge(900);

            Assert.That(deliveryCharge,
                Is.EqualTo(100));
        }

        [Test]
        public void When_CalculateDeliveryCharge_AmountGreaterThanOrEqual1000_ReturnsZero()
        {
            decimal deliveryCharge =
                _orderBillingService.CalculateDeliveryCharge(2000);

            Assert.That(deliveryCharge,
                Is.EqualTo(0));
        }

        [Test]
        public void When_CalculateFinalAmount_EligibleFor10PercentDiscount_ReturnsCorrectAmount()
        {
            decimal finalAmount =
                _orderBillingService.CalculateFinalAmount(1000, 5);

            Assert.That(finalAmount,
                Is.EqualTo(4500));
        }
    }
}