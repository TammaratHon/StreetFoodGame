using Cysharp.Threading.Tasks;
using StreetFoodGame.Domain.Enums;

namespace StreetFoodGame.Application.Interfaces
{
    public interface IApplicationService
    {
        AppState CurrentState { get; }
        UniTask ChangeState(AppState newState);
        void Quit();
    }
}