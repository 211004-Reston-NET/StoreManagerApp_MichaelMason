using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Xunit;

namespace UnitTest
{
    public class RepositoryTest
    {
        private readonly DbContextOptions<StoreManagerContext> _options;
        public RepositoryTest()
        {
            _options = new DbContextOptionsBuilder<StoreManagerContext>()
                        .UseSqlite("Filename = Test.db").Options;
            Seed();
        }
        [Fact]
        public void GetAllCustomersReturnsAllCustomers()
        {
            using (var context = new StoreManagerContext(_options))
            {
                IRepository<Customer> repo = new Repository<Customer>(context);
                var test = repo.GetAll().ToList();
                Assert.Equal(2, test.Count);
                Assert.Equal("Gary Geriatric", test[0].CustName);
            }
        }

        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            using (var context = new StoreManagerContext(_options))
            {
                IRepository<Customer> repo = new Repository<Customer>(context);
                Customer newCust = new Customer
                {
                    CustName = "Steve Sharp",
                    CustAddress = "123 test",
                    CustEmail = "ss1@test.com",
                    CustPhone = "123-456-7890"
                };

                repo.Create(newCust);
                repo.Save();
            }
            using (var context = new StoreManagerContext(_options))
            {
                var result = context.Customers.Single(c => c.CustName.Equals("Steve Sharp"));
                Assert.NotNull(result);
                Assert.Equal("Steve Sharp", result.CustName);
                Assert.Equal("123 test", result.CustAddress);
                Assert.Equal("ss1@test.com", result.CustEmail);
                Assert.Equal("123-456-7890", result.CustPhone);
            }
        }

        [Fact]
        public void FindByIdShouldFindById()
        {
            using (var context = new StoreManagerContext(_options))
            {
                IRepository<Customer> repo = new Repository<Customer>(context);
                var customer = repo.GetByPrimaryKey(1);
                Assert.NotNull(customer.CustName);
                Assert.Equal("Gary Geriatric", customer.CustName);
            }
        }

        [Fact]
        public void GetAllShouldReturnResults()
        {
            using (var context = new StoreManagerContext(_options))
            {
                IRepository<Customer> repo = new Repository<Customer>(context);
                var customer = repo.GetAll();
                Assert.NotEmpty(customer);
                Assert.NotNull(customer);
            }
        }

        [Fact]
        public void DeleteCustomerShouldDeleteCustomer()
        {
            using (var context = new StoreManagerContext(_options))
            {
                IRepository<Customer> repo = new CustomerRepository(context);
                Customer customer = context.Customers.Find(1);
                repo.Delete(customer);
                repo.Save();
            }

            using (var context = new StoreManagerContext(_options))
            {
                List<Customer> custList = context.Customers.ToList();
                Assert.Null(context.Customers.Find(1));
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

                context.SaveChanges();
            }
        }
    }
}