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

        public Food GetRandomMainFood(System.Random random)
        {
            int mainFoodCount = food.main.Length;
            if(mainFoodCount == 0)
            {
                throw new System.InvalidOperationException($"No main foods available for customer order with key: {key}");
            }
            return food.main[random.Next(0, mainFoodCount)];
        }

        public Food GetRandomCarbFood(System.Random random)
        {
            int carbFoodCount = food.carb.Length;
            if(carbFoodCount == 0)
            {
                throw new System.InvalidOperationException($"No carb foods available for customer order with key: {key}");
            }
            return food.carb[random.Next(0, carbFoodCount)];
        }

        public Food GetRandomGrilledFood(System.Random random)
        {
            int grilledFoodCount = food.grilled.Length;
            if(grilledFoodCount == 0)
            {
                throw new System.InvalidOperationException($"No grilled foods available for customer order with key: {key}");
            }
            return food.grilled[random.Next(0, grilledFoodCount)];
        }
    }

}