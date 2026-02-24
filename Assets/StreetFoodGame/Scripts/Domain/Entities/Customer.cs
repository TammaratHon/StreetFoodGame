using StreetFoodGame.Domain.Enums;

namespace StreetFoodGame.Domain.Entities
{
    public class Customer
    {
        public string Name { get; private set; }
        public CustomerMood Mood { get; set; }

        public Customer(string name, CustomerMood mood = CustomerMood.Happy)
        {
            Name = name;
            Mood = mood;
        }
    }
}