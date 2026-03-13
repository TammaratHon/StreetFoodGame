using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace StreetFoodGame.Presentation.Components
{
    [RequireComponent(typeof(Button))]
    public class CookingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image image;
        [SerializeField] private Image highlightImage;

        private Button button;
        public Action onButtonPressed;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);

            // image.gameObject.SetActive(true);
            // highlightImage.gameObject.SetActive(false);
        }

        public void Initialize(Action onClick)
        {
            onButtonPressed = onClick;
        }

        private void OnButtonClick()
        {
            onButtonPressed?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // Color alpha = image.color;
            // alpha.a = 0f;
            // image.color = alpha;

            // highlightImage.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // Color alpha = image.color;
            // alpha.a = 1f;
            // image.color = alpha;

            // highlightImage.gameObject.SetActive(false);
        }
    }
}