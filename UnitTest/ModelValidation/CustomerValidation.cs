using System;
using Xunit;
using Models;

namespace UnitTest
{
    public class CustomerValidation
    {
        Customer testCustomer = new Customer();

        [Fact]
        public void CustomerNumberIsValid()
        {
            testCustomer.CustNumber = 123;
            Assert.Equal(123, testCustomer.CustNumber);
        }

        [Fact]
        public void CustomerNameIsValid()
        {
            var name = "Joe";
            testCustomer.CustName = name;
            Assert.NotNull(testCustomer.CustName);
            Assert.Equal(testCustomer.CustName, name);
        }

        [Theory]
        [InlineData("Abc123")]
        [InlineData("adb@#$")]
        public void CustomerNameThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<FormatException>(() => testCustomer.CustName = input);
        }
        [Theory]
        [InlineData(null)]
        public void CustomerNameThrowsExceptionOnNull(string input)
        {
            Assert.Throws<ArgumentNullException>(() => testCustomer.CustName = input);
        }

        [Fact]
        public void AssertAddressIsValid()
        {
            var address = "123 Test St., Test AK, 00000";
            testCustomer.CustAddress = address;
            Assert.NotNull(testCustomer.CustAddress);
            Assert.Equal(address, testCustomer.CustAddress);
        }

        [Theory]
        [InlineData("!234 test")]
        [InlineData("@234 jkljfs")]
        public void AddressThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<FormatException>(() => testCustomer.CustAddress = input);
        }
        [Theory]
        [InlineData(null)]
        public void AddressThrowsExceptionOnNull(string input)
        {
            Assert.Throws<ArgumentNullException>(() => testCustomer.CustAddress = input);
        }

        [Fact]
        public void CustomerEmailIsValid()
        {
            var email = "joe@test.com";
            testCustomer.CustEmail = email;
            Assert.NotNull(testCustomer.CustEmail);
            Assert.Equal(email, testCustomer.CustEmail);
        }

        [Theory]
        [InlineData("joe!@gmail.com")]
        [InlineData("joe=@gmail.com")]
        [InlineData("joe#@gmail.com")]
        public void EmailThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<FormatException>(() => testCustomer.CustEmail = input);
        }

        [Theory]
        [InlineData(null)]
        public void EmailThrowsExceptionOnNull(string input)
        {
            Assert.Throws<ArgumentNullException>(() => testCustomer.CustEmail = input);
        }
    }
}
