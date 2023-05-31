public class BootStrapState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly ServiceLocator _serviceLocator;

    public BootStrapState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _serviceLocator = ServiceLocator.Instantiate;

        RegisterService();
    }

    public void Enter() => 
        _stateMachine.EnterState<LoadMenuSceneState>();

    private void RegisterService()
    {
        RegisterStaticData();
        _serviceLocator.RegisterService<IGameFactoryService>(new GameFactory(_serviceLocator.GetService<IStaticDataService>()));
    }

    private void RegisterStaticData()
    {
        IStaticDataService staticData = new StaticDataService();
        staticData.LoadPlayers();
        _serviceLocator.RegisterService<IStaticDataService>(staticData);
    }

    public void Exit()
    {
    }
}
