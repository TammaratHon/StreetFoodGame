using System;
using UnityEngine;
using UnityEngine.UI;

public class GameplayView : MonoBehaviour, IGameplayView
{
    // UI Elements
    [SerializeField] private Button optionButton;
    
    // Events
    public event Action OnOptionButtonPressed;

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}