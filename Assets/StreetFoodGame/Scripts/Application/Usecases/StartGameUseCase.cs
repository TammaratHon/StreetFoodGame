namespace StreetFoodGame.Application.Usecases
{
    public class StartGameUseCase
    {
        private readonly ReceiveOrderUseCase receiveOrderUseCase;

        public StartGameUseCase(ReceiveOrderUseCase receiveOrderUseCase)
        {
            this.receiveOrderUseCase = receiveOrderUseCase;
        }

        public void Execute()
        {
            for(int i = 0; i < 3; i++)
            {
                receiveOrderUseCase.CreateOrder();
            }
        }
    }
}