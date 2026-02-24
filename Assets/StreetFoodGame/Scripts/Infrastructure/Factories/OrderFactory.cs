using StreetFoodGame.Domain.Interfaces;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Infrastructure.Factories
{
    public class OrderFactory : IOrderFactory
    {
        private readonly IRecipeRepository recipeRepository;
        private readonly ICustomerRepository customerRepository;

        public OrderFactory(IRecipeRepository recipeRepository, ICustomerRepository customerRepository)
        {
            this.recipeRepository = recipeRepository;
            this.customerRepository = customerRepository;
        }

        public Order CreateOrder()
        {
            Customer customer = customerRepository.GetRandomCustomer();
            Recipe recipe = recipeRepository.GetRandomRecipe();

            return new Order(customer, recipe);
        }
    }
}