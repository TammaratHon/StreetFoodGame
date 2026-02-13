using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class IngredientButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image ingredientImage;
    [SerializeField] private Image highlightImage;

    private Button button;
    private Action onClickAction;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        ingredientImage.gameObject.SetActive(true);
        highlightImage.gameObject.SetActive(false);
    }

    public void Initialize(Action onClick)
    {
        onClickAction = onClick;
    }

    private void OnButtonClick()
    {
        onClickAction?.Invoke();
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