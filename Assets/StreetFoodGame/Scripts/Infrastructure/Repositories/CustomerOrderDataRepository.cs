using System.Collections.Generic;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;
using UnityEngine;
using Newtonsoft.Json;

namespace StreetFoodGame.Infrastructure.Repositories
{
    public class CustomerOrderDataRepository : ICustomerOrderDataRepository
    {
        private const string JSON_PATH = "JSON/CustomerOrderData";

        private readonly List<CustomerOrderData> customerOrderDataList;
        
        public CustomerOrderDataRepository()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(JSON_PATH);
            if (jsonFile == null)
            {
                throw new System.Exception($"Failed to load customer order data from path: {JSON_PATH}");
            }

            customerOrderDataList = JsonConvert.DeserializeObject<List<CustomerOrderData>>(jsonFile.text);
            Debug.Log($"Loaded {customerOrderDataList.Count} customer orders from JSON.");
        }

        public List<CustomerOrderData> GetAllCustomerOrders()
        {
            return customerOrderDataList;
        }

        public CustomerOrderData GetCustomerOrderByKey(string key)
        {
            return customerOrderDataList.Find(order => order.key == key);
        }
    }
}