namespace StreetFoodGame.Domain.Entities
{
    public class Order
    {
        public Customer Customer { get; private set; }
        public Food[] Foods { get; private set; }

        public Order(Customer customer, Food[] foods)
        {
            Customer = customer;
            Foods = foods;
        }
    }
}