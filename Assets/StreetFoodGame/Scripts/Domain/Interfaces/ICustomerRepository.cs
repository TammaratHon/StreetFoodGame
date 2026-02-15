using System.Collections.Generic;

public interface ICustomerRepository
{
    Customer GetCustomerByName(string customerName);
    Customer GetRandomCustomer();
    List<Customer> GetAllCustomers();
}