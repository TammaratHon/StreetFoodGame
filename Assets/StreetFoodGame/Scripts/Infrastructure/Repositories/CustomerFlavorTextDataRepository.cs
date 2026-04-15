using System.Collections.Generic;
using Newtonsoft.Json;
using StreetFoodGame.Domain.Entities;
using StreetFoodGame.Domain.Interfaces;
using UnityEngine;

namespace StreetFoodGame.Infrastructure.Repositories
{
    public class CustomerFlavorTextDataRepository : ICustomerFlavorTextDataRepository
    {
        private const string JSON_PATH = "JSON/CustomerFlavorData";
        private readonly List<CustomerFlavorTextData> customerFlavorTextDataList;

        public CustomerFlavorTextDataRepository()
        {
            TextAsset jsonFile = Resources.Load<TextAsset>(JSON_PATH);
            if(jsonFile == null)
            {
                throw new System.Exception($"Failed to load customer flavor text data from path: {JSON_PATH}");
            }

            customerFlavorTextDataList = JsonConvert.DeserializeObject<List<CustomerFlavorTextData>>(jsonFile.text);
            foreach (var data in customerFlavorTextDataList)
            {
                Debug.Log($"Loaded CustomerFlavorTextData - Key: {data.key}");
                Debug.Log($"Happy Texts: {string.Join(", ", data.happy)}");
                Debug.Log($"Neutral Texts: {string.Join(", ", data.neutral)}");
                Debug.Log($"Impatient Texts: {string.Join(", ", data.impatient)}");
                Debug.Log($"Angry Texts: {string.Join(", ", data.angry)}");
            }
        }

        public List<CustomerFlavorTextData> GetAllCustomerFlavorTexts()
        {
            return customerFlavorTextDataList;
        }

        public CustomerFlavorTextData GetCustomerFlavorTextByKey(string key)
        {
            return customerFlavorTextDataList.Find(x => x.key == key);
        }
    }
}