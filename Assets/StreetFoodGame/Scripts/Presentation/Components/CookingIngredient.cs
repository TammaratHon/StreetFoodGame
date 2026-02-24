using UnityEngine;
using UnityEngine.UI;

namespace StreetFoodGame.Presentation.Components
{
    [RequireComponent(typeof(Image))]
    public class CookingIngredient : MonoBehaviour
    {
        public string IngredientKey => ingredientKey;
        private string ingredientKey;

        private Image ingredientImage;

        private void Awake()
        {
            ingredientImage = GetComponent<Image>();
            ingredientImage.gameObject.SetActive(false);
        }

        public void ShowIngredient(string ingredientKey, object spriteAsset)
        {
            this.ingredientKey = ingredientKey;

            ingredientImage.gameObject.SetActive(true);
            ingredientImage.sprite = spriteAsset as Sprite;
        }

        public void HideIngredient()
        {
            ingredientKey = "";
            ingredientImage.gameObject.SetActive(false);
        }
    }
}