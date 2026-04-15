using StreetFoodGame.Domain.Enums;

namespace StreetFoodGame.Domain.Entities
{
    public class Customer
    {
        public string Key { get; private set; }
        public float WaitingTime { get; set; }
        public CustomerMood Mood { get; set; }

        public Customer(
            string key,
            float waitingTime = 0f,
            CustomerMood mood = CustomerMood.Happy
            )
        {
            Key = key;
            WaitingTime = waitingTime;
            Mood = mood;
        }
    }
}