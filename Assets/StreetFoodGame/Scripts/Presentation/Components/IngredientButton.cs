using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace StreetFoodGame.Presentation.Components
{
    [RequireComponent(typeof(Button))]
    public class IngredientButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        [SerializeField] private string key;
        [SerializeField] private Image ingredientImage;
        [SerializeField] private Image highlightImage;
        [SerializeField] private Sprite dragIconSprite;
        [SerializeField] private Canvas dragCanvas;
        [SerializeField] private RectTransform targetDropAreaRectTransform;

        public string Key => key;

        private Action onClickAction;
        private IngredientDragIcon activeDragIcon;
        private GameObject dragIconObject;

        private void Awake()
        {
            ingredientImage.gameObject.SetActive(true);
            highlightImage.gameObject.SetActive(false);
        }

        public void Initialize(Action onClick)
        {
            onClickAction = onClick;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (activeDragIcon != null || dragIconSprite == null) return;

            Canvas canvas = dragCanvas != null ? dragCanvas : GetComponentInParent<Canvas>();
            if (canvas == null) return;

            dragIconObject = new GameObject(
                $"{key}_DragIcon",
                typeof(RectTransform),
                typeof(CanvasGroup),
                typeof(Image),
                typeof(IngredientDragIcon)
            );

            dragIconObject.transform.SetParent(canvas.transform, false);

            RectTransform rectTransform = dragIconObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(100, 100); // Adjust size as needed

            Image dragImage = dragIconObject.GetComponent<Image>();
            dragImage.sprite = dragIconSprite;
            dragImage.preserveAspect = true;
            dragImage.raycastTarget = false;
            dragImage.color = Color.white;

            activeDragIcon = dragIconObject.GetComponent<IngredientDragIcon>();
            activeDragIcon.Initialize(canvas, eventData.position, OnDragReleased);
        }

        private void OnDragReleased()
        {
            activeDragIcon = null;

            if (RectTransformUtility.RectangleContainsScreenPoint(targetDropAreaRectTransform, Input.mousePosition, null))
            {
                onClickAction?.Invoke();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Color alpha = ingredientImage.color;
            alpha.a = 0f;
            ingredientImage.color = alpha;

            highlightImage.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Color alpha = ingredientImage.color;
            alpha.a = 1f;
            ingredientImage.color = alpha;

            highlightImage.gameObject.SetActive(false);
        }
    }
}