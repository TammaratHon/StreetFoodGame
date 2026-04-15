using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StreetFoodGame.Presentation.Views
{
    public class OrderSlotView : MonoBehaviour
    {
        [SerializeField] private Image customerImage;
        [SerializeField] private Image customerMoodImage;
        [SerializeField] private TMP_Text customerOrderText;
        [SerializeField] private TMP_Text customerFlavorText;

        public void SetCustomerImage(Sprite sprite)
        {
            customerImage.sprite = sprite;
        }

        public void SetCustomerMoodImage(Sprite sprite)
        {
            customerMoodImage.sprite = sprite;
        }

        public void SetCustomerOrderText(string orderText)
        {
            customerOrderText.text = orderText;
        }

        public void SetCustomerFlavorText(string flavorText)
        {
            customerFlavorText.text = flavorText;
        }
    }
}