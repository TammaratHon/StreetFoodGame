public class MainMenuPresenter
{
    private readonly IMainMenuView view;
    private readonly ISceneService sceneService;

    public MainMenuPresenter(IMainMenuView view, ISceneService sceneService)
    {
        this.view = view;
        this.sceneService = sceneService;

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
        sceneService.UnloadScene(
            "MainMenu",
            () =>
            {
                Dispose();
            }
        );
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