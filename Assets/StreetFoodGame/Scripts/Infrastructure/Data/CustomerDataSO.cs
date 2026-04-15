using UnityEngine;

namespace StreetFoodGame.Infrastructure.Data
{
    [CreateAssetMenu(fileName = "CustomerData", menuName = "StreetFoodGame/CustomerData")]
    public class CustomerDataSO : ScriptableObject
    {
        public string CustomerKey;
        public string[] BeginSentences;
        public string[] MiddleSentences;
        public string[] EndSentences;
    }
}