using Data;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Business
{

    public class CustomerBL : BaseBL<Customer>, ICustomerBL
    {
        protected readonly ICustomerRepository customerRepository;

        public CustomerBL(ICustomerRepository customerRepository) : base(customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetByPrimaryKeyWithNav(int id)
        {
            return customerRepository.GetByPrimaryKeyWithNav(id);
        }

        public IEnumerable<Customer> SearchByName(string query)
        {
            return repository.GetAll().Where(c => c.CustName.ToLower().Contains(query));
        }

        public IEnumerable<Customer> SearchByAddress(string query)
        {
            return repository.GetAll().Where(c => c.CustAddress.ToLower().Contains(query));
        }

        public IEnumerable<Customer> SearchByPhone(string query)
        {
            return repository.GetAll().Where(c => c.CustPhone.Equals(query));
        }

        public IEnumerable<Customer> SearchByEmail(string query)
        {
            return repository.GetAll().Where(c => c.CustEmail.ToLower().Contains(query));
        }
    }
}
