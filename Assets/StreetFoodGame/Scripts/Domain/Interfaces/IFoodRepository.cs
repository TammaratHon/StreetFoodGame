using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Domain.Interfaces
{
    public interface IFoodRepository
    {
        Food GetRandomFoodWithoutMain();
        Food GetMainFood();
    }
}