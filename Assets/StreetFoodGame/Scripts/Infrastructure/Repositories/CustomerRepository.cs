using System;
using System.Collections.Generic;
using StreetFoodGame.Domain.Interfaces;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Infrastructure.Data;

namespace StreetFoodGame.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customerDataList;

        public CustomerRepository(List<CustomerDataSO> customerDataList)
        {
            this.customerDataList = new List<Customer>();
            foreach (var data in customerDataList)
            {
                var customer = ConvertToCustomer(data);
                this.customerDataList.Add(customer);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return customerDataList;
        }

        public Customer GetCustomerByKey(string customerKey)
        {
            return customerDataList.Find(customer => customer.Key == customerKey);
        }

        public Customer GetRandomCustomer()
        {
            if (customerDataList.Count == 0)
            {
                return null;
            }

            Random random = new Random();
            int randomIndex = random.Next(customerDataList.Count);
            return customerDataList[randomIndex];
        }

        private Customer ConvertToCustomer(CustomerDataSO data)
        {
            return new Customer(
                data.CustomerKey,
                data.BeginSentences,
                data.MiddleSentences,
                data.EndSentences
            );
        }
    }
}