using VContainer.Unity;
using StreetFoodGame.Domain.Enums;
using StreetFoodGame.Application.Interfaces;

public class GameStarter : IStartable
{
    private readonly IApplicationService applicationService;
    
    public GameStarter(IApplicationService applicationService)
    {
        this.applicationService = applicationService;
    }

    public void Start()
    {
        applicationService.ChangeState(AppState.MainMenu);
    }
}