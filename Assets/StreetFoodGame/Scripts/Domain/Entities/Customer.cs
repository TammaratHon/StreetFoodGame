using StreetFoodGame.Domain.Enums;

namespace StreetFoodGame.Domain.Entities
{
    public class Customer
    {
        public string Key { get; private set; }
        public string[] BeginSentences { get; set; }
        public string[] MiddleSentences { get; set; }
        public string[] EndSentences { get; set; }
        public CustomerMood Mood { get; set; }

        public Customer(
            string key,
            string[] beginSentences,
            string[] middleSentences,
            string[] endSentences,
            CustomerMood mood = CustomerMood.Happy
            )
        {
            Key = key;
            BeginSentences = beginSentences;
            MiddleSentences = middleSentences;
            EndSentences = endSentences;
            Mood = mood;
        }
    }
}