using System.Collections.Generic;

namespace StreetFoodGame.Application.Usecases
{
    public class ServeUsecase
    {
        private const int MAX_FOOD_PER_SERVE = 5;

        private readonly List<string> currentFoods = new List<string>();

        public ServeUsecase()
        {
            
        }

        public void AddFood(string foodKey)
        {
            currentFoods.Add(foodKey);
        }

        public bool IsIngredientSlotAvailable()
        {
            return currentFoods.Count < MAX_FOOD_PER_SERVE;
        }

        public List<string> GetCurrentFoods()
        {
            return new List<string>(currentFoods);
        }
    }
}