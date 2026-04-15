using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Domain.Interfaces
{
    public interface IFoodDataRepository
    {
        FoodData GetRandomFoodWithoutMain();
        FoodData GetMainFood();
    }
}