using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;

namespace StreetFoodGame.Domain.Interfaces
{
    public interface ICustomerFlavorTextDataRepository
    {
        List<CustomerFlavorTextData> GetAllCustomerFlavorTexts();
        CustomerFlavorTextData GetCustomerFlavorTextByKey(string key);
    }
}