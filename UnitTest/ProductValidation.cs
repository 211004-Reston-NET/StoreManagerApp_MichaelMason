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
        public void ProductNameThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<FormatException>(() => testProduct.ProdName = input);
        }
        [Theory]
        [InlineData(null)]
        public void ProductNameThrowsExceptionOnNull(string input)
        {
            Assert.Throws<ArgumentNullException>(() => testProduct.ProdName = input);
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
        public void ProductDescriptionThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<FormatException>(() => testProduct.ProdDescription = input);
        }
        [InlineData(null)]
        public void ProductDescriptionThrowsExceptionOnNull(string input)
        {
            Assert.Throws<ArgumentNullException>(() => testProduct.ProdDescription = input);
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
        public void ProductCategoryThrowsExceptionOnInvalid(string input)
        {
            Assert.Throws<FormatException>(() => testProduct.ProdCategory = input);
        }
        [Theory]
        [InlineData(null)]
        public void ProductCategoryThrowsExceptionOnNull(string input)
        {
            Assert.Throws<ArgumentNullException>(() => testProduct.ProdCategory = input);
        }
    }
}