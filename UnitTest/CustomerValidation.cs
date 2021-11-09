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
        [InlineData(null)]
        public void CustomerNameThrowsException(string input)
        {
            Assert.Throws<Exception>(() => testCustomer.CustName = input);
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
        [InlineData(null)]
        public void InvalidAddressThrowsException(string input)
        {
            Assert.Throws<Exception>(() => testCustomer.CustAddress = input);
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
        [InlineData(null)]
        public void EmailThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<Exception>(() => testCustomer.CustEmail = input);
        }
    }
}
