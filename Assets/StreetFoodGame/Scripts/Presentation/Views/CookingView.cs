using System;
using UnityEngine;
using StreetFoodGame.Application.Interfaces;
using StreetFoodGame.Presentation.Components;
using UnityEngine.UI;

namespace StreetFoodGame.Presentation.Views
{
    public class CookingView : MonoBehaviour, ICookingView
    {
        [SerializeField] private IngredientButton[] _ingredientButton;

        [SerializeField] private CookingButton _cookButton;
        [SerializeField] private AvatarAnimator avatarAnimator;
        [SerializeField] private Image resultImage;

        public event Action<string> OnIngredientButtonPressed;
        public event Action OnCookButtonPressed;

        private void Awake()
        {
            foreach (var button in _ingredientButton)
            {
                button.Initialize(() => OnIngredientButtonPressed?.Invoke(button.Key));
            }

            _cookButton.Initialize(() => OnCookButtonPressed?.Invoke());

            HideCookingResult();
        }

        public void PlayAvatarCookingAnimation(int step)
        {
            avatarAnimator.PlayCookingAnimation(step);
        }

        public void PlayAvatarIdleAnimation()
        {
            avatarAnimator.PlayIdleAnimation();
        }

        public void ShowCookingResult(object resultSprite)
        {
            resultImage.sprite = resultSprite as Sprite;
            resultImage.gameObject.SetActive(true);
        }

        public void HideCookingResult()
        {
            resultImage.gameObject.SetActive(false);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}