using StreetFoodGame.Domain.Interfaces;
using StreetFoodGame.Domain.Entities;
using UnityEngine;

namespace StreetFoodGame.Infrastructure.Factories
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IFoodDataRepository foodRepository;
        private readonly ICustomerOrderDataRepository customerRepository;

        public OrderFactory(IFoodDataRepository foodRepository, ICustomerOrderDataRepository customerRepository)
        {
            this.foodRepository = foodRepository;
            this.customerRepository = customerRepository;
        }

        public Order CreateOrder(int recipeCount = 1)
        {
            Customer customer = GetRandomCustomer();
            FoodData[] foods = new FoodData[recipeCount];

            foods[0] = foodRepository.GetMainFood();
            for(int i = 1; i < recipeCount; i++)
            {
                foods[i] = foodRepository.GetRandomFoodWithoutMain();
            }

            return new Order(customer, foods);
        }

        private Customer GetRandomCustomer()
        {
            int customerCount = customerRepository.GetAllCustomerOrders().Count;
            var customerData = customerRepository.GetAllCustomerOrders()[Random.Range(0, customerCount)];
            return new Customer(customerData.key);
        }
    }
}