namespace StreetFoodGame.Domain.Entities
{
    public class Order
    {
        public Customer Customer { get; private set; }
        public FoodData[] Foods { get; private set; }

        public Order(Customer customer, FoodData[] foods)
        {
            Customer = customer;
            Foods = foods;
        }
    }
}