public class LoadMenuSceneState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;

    public LoadMenuSceneState(StateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        MenuPlayButton.PlayButtonPressed += LoadMainSeneState;
    }

    public void Enter()
    {
        _curtain.Show();
        _sceneLoader.Load("MenuScene");
        _curtain.Hide();
    }

    private void LoadMainSeneState(int playersValue) => 
        _stateMachine.EnterState<LoadMainSceneState, int>(playersValue);

    public void Exit()
    {
    }
}