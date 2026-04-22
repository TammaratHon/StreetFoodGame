using System;
using UnityEngine;
using UnityEngine.UI;

namespace StreetFoodGame.Presentation.Components
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    public class IngredientDragIcon : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Canvas parentCanvas;
        private Camera uiCamera;
        private Action onReleaseAction;
        private bool isDragging;

        public void Initialize(Canvas canvas, Vector2 initialPointerPosition, Action onRelease)
        {
            rectTransform = GetComponent<RectTransform>();
            parentCanvas = canvas;
            uiCamera = parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : parentCanvas.worldCamera;
            onReleaseAction = onRelease;
            isDragging = true;

            UpdatePosition(initialPointerPosition);
        }

        private void Update()
        {
            if (!isDragging || parentCanvas == null) return;

            Vector2 pointerPosition = Input.mousePosition;
            if (Input.touchCount > 0)
            {
                pointerPosition = Input.GetTouch(0).position;
            }

            UpdatePosition(pointerPosition);

            bool released = Input.touchCount == 0 && !Input.GetMouseButton(0);
            if (!released) return;

            isDragging = false;
            onReleaseAction?.Invoke();
            Destroy(gameObject);
        }

        private void UpdatePosition(Vector2 screenPosition)
        {
            RectTransform canvasRect = parentCanvas.transform as RectTransform;
            if (canvasRect == null) return;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPosition, uiCamera, out Vector2 localPoint))
            {
                rectTransform.anchoredPosition = localPoint;
            }
        }
    }
}
