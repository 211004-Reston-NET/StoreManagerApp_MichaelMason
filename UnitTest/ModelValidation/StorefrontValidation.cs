using System;
using Xunit;
using Models;

namespace UnitTest
{
    public class StorefrontValidation
    {
        Storefront testStorefront = new Storefront();
        [Fact]
        public void StoreNameIsValid()
        {
            var name = "Joe's Boot Emporium";
            testStorefront.StoreName = name;
            Assert.NotNull(testStorefront.StoreName);
            Assert.Equal(name, testStorefront.StoreName);
        }

        [Theory]
        [InlineData("Joe's b@@t emporium")]
        [InlineData("Joe's Boot% emporium")]
        public void StoreNameThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<FormatException>(() => testStorefront.StoreName = input);
        }
        [Theory]
        [InlineData(null)]
        public void StoreNameThrowsExceptionOnNull(string input)
        {
            Assert.Throws<ArgumentNullException>(() => testStorefront.StoreName = input);
        }

        [Fact]
        public void StoreAddressIsValid()
        {
            var address = "123 Test Way, Test AL, 00000-0000";
            testStorefront.StoreAddress = address;
            Assert.NotNull(testStorefront.StoreAddress);
            Assert.Equal(address, testStorefront.StoreAddress);
        }

        [Theory]
        [InlineData("@()&&!")]
        [InlineData(":}{|:?")]
        public void StoreAddressThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<FormatException>(() => testStorefront.StoreAddress = input);
        }
        [Theory]
        [InlineData(null)]
        public void StoreAddressThrowsExceptionOnNull(string input)
        {
            Assert.Throws<ArgumentNullException>(() => testStorefront.StoreAddress = input);
        }
    }
}