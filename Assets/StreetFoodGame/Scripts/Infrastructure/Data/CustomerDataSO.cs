using UnityEngine;

namespace StreetFoodGame.Infrastructure.Data
{
    [CreateAssetMenu(fileName = "CustomerData", menuName = "StreetFoodGame/CustomerData")]
    public class CustomerDataSO : ScriptableObject
    {
        public string customerName;
        public Sprite customerSprite;
    }
}