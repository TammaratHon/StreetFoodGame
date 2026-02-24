using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Domain.Interfaces
{
    public interface IOrderFactory
    {
        Order CreateOrder();
    }
}