using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Application.Interfaces
{
    public interface IOrderQueueView
    {
        void AddOrder(Customer customer, List<Recipe> recipes);
        void RemoveOrder(Customer customer);
    }
}