using System;

public class MainMenuPresenter
{
    private readonly IMainMenuView view;
    private readonly ISceneService sceneService;
    private readonly Action onGameStarted;

    public MainMenuPresenter(IMainMenuView view, ISceneService sceneService, Action onGameStarted)
    {
        this.view = view;
        this.sceneService = sceneService;
        this.onGameStarted = onGameStarted;

        view.OnStartGameButtonPressed += HandleStartGameButtonPressed;
        view.OnOptionsButtonPressed += HandleOptionsButtonPressed;
        view.OnExitButtonPressed += HandleExitButtonPressed;
    }

    public void Show()
    {
        view.Show();
    }

    private void HandleStartGameButtonPressed()
    {
        view.Hide();
        onGameStarted.Invoke();
    }

    private void HandleOptionsButtonPressed()
    {
        // Implement options menu logic here
    }

    private void HandleExitButtonPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit();
#endif
    }

    private void Dispose()
    {
        view.OnStartGameButtonPressed -= HandleStartGameButtonPressed;
        view.OnOptionsButtonPressed -= HandleOptionsButtonPressed;
        view.OnExitButtonPressed -= HandleExitButtonPressed;
    }
}