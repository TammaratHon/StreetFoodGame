using UnityEngine;
using UnityEngine.UI;

namespace StreetFoodGame.Presentation.Components
{
    public class CookingIngredient : MonoBehaviour
    {
        public string IngredientKey => ingredientKey;
        private string ingredientKey;

        [SerializeField] private Image ingredientImage;

        public void ShowIngredient(string ingredientKey, object spriteAsset)
        {
            if(ingredientImage == null) return;
            this.ingredientKey = ingredientKey;

            gameObject.SetActive(true);
            ingredientImage.sprite = spriteAsset as Sprite;
        }

        public void HideIngredient()
        {
            if(ingredientImage == null) return;
            ingredientKey = "";
            gameObject.SetActive(false);
        }
    }
}