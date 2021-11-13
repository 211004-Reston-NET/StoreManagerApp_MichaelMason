using System;
using Xunit;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
//https://stackoverflow.com/questions/2167811/unit-testing-asp-net-dataannotations-validation

namespace UnitTest
{
    public class ProductValidation
    {
        [Fact]
        public void ProductNameRequired()
        {
            var prod = new Product
            {
                ProdName = null,
                ProdPrice = (decimal)1.99,
                ProdDescription = "kjahf",
                ProdCategory = "ljkhaf"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(prod, null, null);
            Assert.False(Validator.TryValidateObject(prod, ctx, validationResults, true));
        }

        [Fact]
        public void ProductNameValid()
        {
            var prod = new Product
            {
                ProdName = "jlkhf897)(*()*_)(*",
                ProdPrice = (decimal)1.99,
                ProdDescription = "kjahf",
                ProdCategory = "ljkhaf"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(prod, null, null);
            Assert.False(Validator.TryValidateObject(prod, ctx, validationResults, true));
        }

        [Fact]
        public void ProductPriceRequired()
        {
            var prod = new Product
            {
                ProdName = "kljahf",
                ProdDescription = "kjahf",
                ProdCategory = "ljkhaf"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(prod, null, null);
            Assert.False(Validator.TryValidateObject(prod, ctx, validationResults, true));
        }

        [Fact]
        public void ProductPriceValid()
        {
            var prod = new Product
            {
                ProdName = "asfdsf",
                ProdPrice = 0,
                ProdDescription = "kjahf",
                ProdCategory = "ljkhaf"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(prod, null, null);
            Assert.False(Validator.TryValidateObject(prod, ctx, validationResults, true));
        }

        [Fact]
        public void ProductDescriptionRequired()
        {
            var prod = new Product
            {
                ProdName = "kljahf",
                ProdPrice = (decimal)1.99,
                ProdDescription = null,
                ProdCategory = "ljkhaf"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(prod, null, null);
            Assert.False(Validator.TryValidateObject(prod, ctx, validationResults, true));
        }

        [Fact]
        public void ProductDescriptionValid()
        {
            var prod = new Product
            {
                ProdName = "kljhlk",
                ProdPrice = (decimal)1.99,
                ProdDescription = "KJLHLI&*)(*)",
                ProdCategory = "ljkhaf"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(prod, null, null);
            Assert.False(Validator.TryValidateObject(prod, ctx, validationResults, true));
        }

        [Fact]
        public void ProductCategoryRequired()
        {
            var prod = new Product
            {
                ProdName = "kljahf",
                ProdPrice = (decimal)1.99,
                ProdDescription = "kjahf",
                ProdCategory = null
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(prod, null, null);
            Assert.False(Validator.TryValidateObject(prod, ctx, validationResults, true));
        }

        [Fact]
        public void ProductCategoryValid()
        {
            var prod = new Product
            {
                ProdName = "jlkhf",
                ProdPrice = (decimal)1.99,
                ProdDescription = "kjahf",
                ProdCategory = ")*(&*YHKLJH"
            };

            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(prod, null, null);
            Assert.False(Validator.TryValidateObject(prod, ctx, validationResults, true));
        }
    }
}
