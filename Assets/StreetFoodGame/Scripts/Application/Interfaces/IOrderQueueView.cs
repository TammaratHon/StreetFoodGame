using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Application.Interfaces
{
    public interface IOrderQueueView
    {
        void AddOrder(Customer customer, string sentence);
        void RemoveOrder(Customer customer);
    }
}