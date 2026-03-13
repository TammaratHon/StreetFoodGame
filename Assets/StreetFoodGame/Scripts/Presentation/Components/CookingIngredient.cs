using UnityEngine;
using UnityEngine.UI;

namespace StreetFoodGame.Presentation.Components
{
    public class CookingIngredient : MonoBehaviour
    {
        public string IngredientKey => ingredientKey;
        private string ingredientKey;

        [SerializeField] private Image ingredientImage;
        [SerializeField] private CookingIngredientAnimator animator;

        public void ShowIngredient(string ingredientKey, object spriteAsset)
        {
            if(ingredientImage == null) return;
            this.ingredientKey = ingredientKey;

            gameObject.SetActive(true);
            ingredientImage.sprite = spriteAsset as Sprite;

            if(animator != null)
            {
                animator.PlayShowAnimation();
            }
        }

        public void ChangePosition(Vector3 newPosition, bool instant = false)
        {
            if(animator == null || instant)
            {
                transform.position = newPosition;
            } else
            {
                animator.LerpToPosition(newPosition);
            }
        }

        public void HideIngredient()
        {
            if(ingredientImage == null) return;
            ingredientKey = "";

            if(animator == null)
            {
                gameObject.SetActive(false);
            } else
            {
                animator.PlayHideAnimation();
            }
        }
    }
}