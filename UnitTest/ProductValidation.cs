using System;
using Xunit;
using Models;

namespace UnitTest
{
    public class ProductValidation
    {
        Product testProduct = new Product();
        [Fact]
        public void ProductNameIsValid()
        {
            var name = "Football";
            testProduct.ProdName = name;
            Assert.NotNull(testProduct.ProdName);
            Assert.Equal(name, testProduct.ProdName);
        }
        [Theory]
        [InlineData("F@@tolkjh")]
        [InlineData("%*&@*&")]
        [InlineData(null)]
        public void ProductNameThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<Exception>(() => testProduct.ProdName = input);
        }
        [Fact]
        public void ProductDescriptionIsValid()
        {
            var name = "Officially licensed NFL football";
            testProduct.ProdDescription = name;
            Assert.NotNull(testProduct.ProdDescription);
            Assert.Equal(name, testProduct.ProdDescription);
        }
        [Theory]
        [InlineData("F@@tolkjh")]
        [InlineData("%*&@*&")]
        [InlineData(null)]
        public void ProductDescriptionThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<Exception>(() => testProduct.ProdDescription = input);
        }

        [Fact]
        public void ProductCategoryIsValid()
        {
            var name = "Sporting goods";
            testProduct.ProdCategory = name;
            Assert.NotNull(testProduct.ProdCategory);
            Assert.Equal(name, testProduct.ProdCategory);
        }
        [Theory]
        [InlineData("F@@tolkjh")]
        [InlineData("%*&@*&")]
        [InlineData(null)]
        public void ProductCategoryThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<Exception>(() => testProduct.ProdCategory = input);
        }
    }
}