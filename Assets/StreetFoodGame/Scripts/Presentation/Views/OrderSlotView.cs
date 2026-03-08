using TMPro;
using UnityEngine;

namespace StreetFoodGame.Presentation.Views
{
    public class OrderSlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text avatar;
        [SerializeField] private TMP_Text[] foodIcons;

        public void SetAvatar(string name)
        {
            avatar.text = name;
        }

        public void SetFoodIcons(string[] name)
        {
            foreach (var icon in foodIcons)
            {
                icon.gameObject.SetActive(false);
            }

            for (int i = 0; i < name.Length; i++)
            {
                foodIcons[i].text = name[i];
                foodIcons[i].gameObject.SetActive(true);
            }
        }
    }
}