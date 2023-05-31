public class LoadMainSceneState : IPayLoadedState<int>
{
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactoryService _gameFactory;
    private readonly LoadingCurtain _curtain;
    private int _valuePlayers;

    public LoadMainSceneState(StateMachine stateMachine, SceneLoader sceneLoader, IGameFactoryService gameFactory, LoadingCurtain curtain)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _gameFactory = gameFactory;
        _curtain = curtain;
        EndGameButton.EndGame += LoadMenuSceneState;
    }

    public void Enter(int valuePlayers)
    {
        _curtain.Show();
        _valuePlayers = valuePlayers;
        _sceneLoader.Load("MainScene", CreateObjects);
        _curtain.Hide();
    }

    public void Exit()
    {
    }

    private void CreateObjects()
    {
        _gameFactory.CreatePoints();
        _gameFactory.CreatePlayers(_valuePlayers);
    }

    private void LoadMenuSceneState()
    {
        _stateMachine.EnterState<LoadMenuSceneState>();
    }
}
