public class GameplayPresenter
{
    private readonly IGameplayView _view;
    private readonly ICookingView _cookingView;
    private readonly ISceneService _sceneService;

    public GameplayPresenter(IGameplayView view, ICookingView cookingView, ISceneService sceneService)
    {
        _view = view;
        _cookingView = cookingView;
        _sceneService = sceneService;
    }

    public void StartGameplay()
    {
        // Additional logic to initialize gameplay can be added here.
        _view.Show();
        _cookingView.Show();
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