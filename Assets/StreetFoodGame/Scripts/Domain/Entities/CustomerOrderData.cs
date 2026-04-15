namespace StreetFoodGame.Domain.Entities
{
    [System.Serializable]
    public class CustomerOrderData
    {
        public string key;
        public string name;
        public string[] beginning_sentence;
        public string[] middle_sentence;
        public string[] end_sentence;
        public FoodList food;
        
        public struct FoodList
        {
            public Food[] main;
            public Food[] carb;
            public Food[] grilled;
        }

        public struct Food
        {
            public string key;
            public int amount_min;
            public int amount_max;
        }
    }

}