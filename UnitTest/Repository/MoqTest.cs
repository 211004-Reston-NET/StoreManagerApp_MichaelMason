using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;
using Moq;
using Xunit;

namespace UnitTest
{
    public class MoqTest
    {
        [Fact]
        public void GetAllCustomersReturnsAllCustomers()
        {
            var custRepo = new Mock<ICustomerRepository>();
            var joe = new Customer
            {
                CustName = "joe",
                CustAddress = "123",
                CustEmail = "aaa",
                CustPhone = "123"
            };
            custRepo.Setup(c => c.GetAll())
            .Returns(new List<Customer>
            {
                joe
            });

            var custBL = new CustomerBL(custRepo.Object);
            IEnumerable<Customer> result = custBL.GetAll();
            Assert.Single(result);
        }
    }
}