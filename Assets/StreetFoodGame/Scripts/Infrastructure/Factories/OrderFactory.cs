using StreetFoodGame.Domain.Interfaces;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Infrastructure.Factories
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IFoodRepository foodRepository;
        private readonly ICustomerRepository customerRepository;

        public OrderFactory(IFoodRepository foodRepository, ICustomerRepository customerRepository)
        {
            this.foodRepository = foodRepository;
            this.customerRepository = customerRepository;
        }

        public Order CreateOrder(int recipeCount = 1)
        {
            Customer customer = customerRepository.GetRandomCustomer();
            Food[] foods = new Food[recipeCount];

            foods[0] = foodRepository.GetMainFood();
            for(int i = 1; i < recipeCount; i++)
            {
                foods[i] = foodRepository.GetRandomFoodWithoutMain();
            }

            return new Order(customer, foods);
        }
    }
}