using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour, IMainMenuView
{
    // UI Elements
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;

    // Events
    public event Action OnStartGameButtonPressed;
    public event Action OnOptionsButtonPressed;
    public event Action OnExitButtonPressed;

    private void Awake()
    {
        if(startGameButton != null)
            startGameButton.onClick.AddListener(() => OnStartGameButtonPressed?.Invoke());

        if(optionsButton != null)
            optionsButton.onClick.AddListener(() => OnOptionsButtonPressed?.Invoke());

        if(exitButton != null)
            exitButton.onClick.AddListener(() => OnExitButtonPressed?.Invoke());
    }

    private void OnDestroy()
    {
        if(startGameButton != null)
            startGameButton.onClick.RemoveAllListeners();

        if(optionsButton != null)
            optionsButton.onClick.RemoveAllListeners();

        if(exitButton != null)
            exitButton.onClick.RemoveAllListeners();
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