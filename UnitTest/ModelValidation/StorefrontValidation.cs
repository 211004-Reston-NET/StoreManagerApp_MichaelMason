using System;
using Xunit;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
//https://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation

namespace UnitTest
{
    public class StorefrontValidation
    {
        [Fact]
        public void StorefrontNameRequired()
        {
            var store = new Storefront
            {
                StoreName = null,
                StoreAddress = "lkhfdsalkjh"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(store, null);
            Assert.False(Validator.TryValidateObject(store, ctx, validationResults, true));
        }

        [Fact]
        public void StorefrontNameValid()
        {
            var store = new Storefront
            {
                StoreName = "JHO()()*_)()*",
                StoreAddress = "lkhfdsalkjh"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(store, null);
            Assert.False(Validator.TryValidateObject(store, ctx, validationResults, true));
        }

        [Fact]
        public void StorefrontAddressRequired()
        {
            var store = new Storefront
            {
                StoreName = "jkhljk",
                StoreAddress = null
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(store, null);
            Assert.False(Validator.TryValidateObject(store, ctx, validationResults, true));
        }

        [Fact]
        public void StorefrontAddressValid()
        {
            var store = new Storefront
            {
                StoreName = "jkh",
                StoreAddress = "1213 #(*()@#*"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(store, null);
            Assert.False(Validator.TryValidateObject(store, ctx, validationResults, true));
        }
    }
}
