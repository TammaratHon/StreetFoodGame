public class GameplayPresenter
{
    private readonly IGameplayView _view;
    private readonly ISceneService _sceneService;

    public GameplayPresenter(IGameplayView view, ISceneService sceneService)
    {
        _view = view;
        _sceneService = sceneService;
    }

    public void StartGameplay()
    {
        // Additional logic to initialize gameplay can be added here.
        _view.Show();
    }

    public void EndGameplay()
    {
        _sceneService.UnloadScene(
            "Gameplay",
            OnGameplaySceneUnloaded
        );
    }

    private void OnGameplaySceneUnloaded()
    {
        // Additional logic after the gameplay scene is unloaded can be added here.
    }
}