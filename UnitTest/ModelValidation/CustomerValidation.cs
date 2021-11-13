using System;
using Xunit;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
//https://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation

namespace UnitTest
{
    public class CustomerValidation
    {
        [Fact]
        public void CustomerNameRequired()
        {
            var cust = new Customer
            {
                CustName = null,
                CustAddress = "jkhakf",
                CustEmail = "lksjdf",
                CustPhone = "2098342432"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(cust, null, null);
            Assert.False(Validator.TryValidateObject(cust, ctx, validationResults, true));
        }

        [Fact]
        public void CustomerNameValid()
        {
            var cust = new Customer
            {
                CustName = "(*()*$!,",
                CustAddress = "jkhakf",
                CustEmail = "lksjdf",
                CustPhone = "2098342432"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(cust, null, null);
            Assert.False(Validator.TryValidateObject(cust, ctx, validationResults, true));
        }


        [Fact]
        public void CustomerEmailRequired()
        {
            var cust = new Customer
            {
                CustName = "kjhaksjf",
                CustAddress = "jkhakf",
                CustEmail = null,
                CustPhone = "2098342432"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(cust, null, null);
            Assert.False(Validator.TryValidateObject(cust, ctx, validationResults, true));
        }

        [Fact]
        public void CustomerEmailValid()
        {
            var cust = new Customer
            {
                CustName = "asdffda,",
                CustAddress = "asdf",
                CustEmail = "KLHJ(*)_",
                CustPhone = "2098342432"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(cust, null, null);
            Assert.False(Validator.TryValidateObject(cust, ctx, validationResults, true));
        }

        [Fact]
        public void CustomerAddressRequired()
        {
            var cust = new Customer
            {
                CustName = "ljakhf",
                CustAddress = null,
                CustEmail = "lksjdf",
                CustPhone = "2098342432"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(cust, null, null);
            Assert.False(Validator.TryValidateObject(cust, ctx, validationResults, true));
        }

        [Fact]
        public void CustomerAddressValid()
        {
            var cust = new Customer
            {
                CustName = "asdfasdf",
                CustAddress = "KHJ*(&()",
                CustEmail = "lksjdf",
                CustPhone = "2098342432"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(cust, null, null);
            Assert.False(Validator.TryValidateObject(cust, ctx, validationResults, true));
        }

        [Fact]
        public void CustomerPhoneRequired()
        {
            var cust = new Customer
            {
                CustName = "kljh",
                CustAddress = "jkhakf",
                CustEmail = "lksjdf",
                CustPhone = null
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(cust, null, null);
            Assert.False(Validator.TryValidateObject(cust, ctx, validationResults, true));
        }

        [Fact]
        public void CustomerPhoneValid()
        {
            var cust = new Customer
            {
                CustName = "(*()*$!,",
                CustAddress = "jkhakf",
                CustEmail = "lksjdf",
                CustPhone = "jh9809890afuo"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(cust, null, null);
            Assert.False(Validator.TryValidateObject(cust, ctx, validationResults, true));
        }
    }
}
