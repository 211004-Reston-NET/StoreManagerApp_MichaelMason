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

        /// <summary>
        /// Gets customer entity with associated navigation properties via eager load
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Customer entity</returns>
        public Customer GetByPrimaryKeyWithNav(int id)
        {
            return customerRepository.GetByPrimaryKeyWithNav(id);
        }

        /// <summary>
        /// Searches customer entities by name field
        /// </summary>
        /// <param name="query">string</param>
        /// <returns>IEnumerable<Customer></returns>
        public IEnumerable<Customer> SearchByName(string query)
        {
            return repository.GetAll().Where(c => c.CustName.ToLower().Contains(query.ToLower()));
        }

        /// <summary>
        /// Searches customer entities by address field
        /// </summary>
        /// <param name="query">string</param>
        /// <returns>IEnumerable<Customer></returns>
        public IEnumerable<Customer> SearchByAddress(string query)
        {
            return repository.GetAll().Where(c => c.CustAddress.ToLower().Contains(query));
        }

        /// <summary>
        /// Searches customer entities by phone field
        /// </summary>
        /// <param name="query">string</param>
        /// <returns>IEnumerable<Customer></returns>
        public IEnumerable<Customer> SearchByPhone(string query)
        {
            return repository.GetAll().Where(c => c.CustPhone.Equals(query));
        }

        /// <summary>
        /// Searches customer entities by email field
        /// </summary>
        /// <param name="query">string</param>
        /// <returns>IEnumerable<Customer></returns>
        public IEnumerable<Customer> SearchByEmail(string query)
        {
            return repository.GetAll().Where(c => c.CustEmail.ToLower().Contains(query));
        }
    }
}
