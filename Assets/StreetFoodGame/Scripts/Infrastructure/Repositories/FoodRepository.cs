using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;
using StreetFoodGame.Infrastructure.Data;
using UnityEngine;

namespace StreetFoodGame.Infrastructure.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private List<Food> mainFoods;
        private List<Food> otherFoods;

        public FoodRepository(List<FoodDataSO> foods)
        {
            mainFoods = new List<Food>();
            otherFoods = new List<Food>();

            foreach (var foodData in foods)
            {
                var food = ConvertToFood(foodData);
                if (foodData.isMainFood)
                {
                    mainFoods.Add(food);
                }
                else
                {
                    otherFoods.Add(food);
                }
            }
        }

        public Food GetMainFood()
        {
            if (mainFoods.Count == 0)
            {
                throw new System.InvalidOperationException("No main foods available in the repository.");
            }

            int randomIndex = Random.Range(0, mainFoods.Count);
            return mainFoods[randomIndex];
        }

        public Food GetRandomFoodWithoutMain()
        {
            if (otherFoods.Count == 0)
            {
                throw new System.InvalidOperationException("No other foods available in the repository.");
            }

            int randomIndex = Random.Range(0, otherFoods.Count);
            return otherFoods[randomIndex];
        }

        private Food ConvertToFood(FoodDataSO data)
        {
            return new Food(data.foodName);
        }
    }
}