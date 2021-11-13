using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Xunit;

namespace UnitTest
{
    public class CustomerRepositoryTest
    {
        private readonly DbContextOptions<StoreManagerContext> _options;
        public CustomerRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<StoreManagerContext>()
                        .UseSqlite("Filename = TestCust.db").Options;
            Seed();
        }

        [Fact]
        public void GetByPrimaryKeyNavItemsShouldPopulate()
        {
            using (var context = new StoreManagerContext(_options))
            {
                ICustomerRepository repo = new CustomerRepository(context);
                var test = repo.GetByPrimaryKeyWithNav(1);
                Assert.NotNull(test);
                Assert.NotEmpty(test.SOrders);
            }
        }

        [Fact]
        public void GetAllWithNavItemsShouldPopulate()
        {
            using (var context = new StoreManagerContext(_options))
            {
                ICustomerRepository repo = new CustomerRepository(context);
                var test = repo.GetAllWithNav();
                Assert.NotNull(test);
                Assert.NotEmpty(test.First().SOrders);
            }
        }

        private void Seed()
        {
            using (var context = new StoreManagerContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customer
                    {
                        CustName = "Gary Geriatric",
                        CustAddress = "123 test",
                        CustEmail = "gg@test.com",
                        CustPhone = "123-456-7890",
                        SOrders = new List<SOrder>
                        { }
                    },
                    new Customer
                    {
                        CustName = "Sam Smith",
                        CustAddress = "123 test",
                        CustEmail = "ss@test.com",
                        CustPhone = "123-456-7890",
                        SOrders = new List<SOrder>
                        { }
                    }
                );

                context.SOrders.AddRange(
                    new SOrder
                    {
                        Date = System.DateTime.Today,
                        StoreNumber = 1,
                        CustNumber = 1,
                        TotalPrice = (decimal)1.00,
                    },
                    new SOrder
                    {
                        Date = System.DateTime.Today,
                        StoreNumber = 1,
                        CustNumber = 2,
                        TotalPrice = (decimal)1.00,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}