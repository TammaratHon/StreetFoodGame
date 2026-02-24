namespace StreetFoodGame.Domain.Entities
{
    public class Order
    {
        public Customer Customer { get; private set; }
        public Recipe Recipe { get; private set; }

        public Order(Customer customer, Recipe recipe)
        {
            Customer = customer;
            Recipe = recipe;
        }
    }
}