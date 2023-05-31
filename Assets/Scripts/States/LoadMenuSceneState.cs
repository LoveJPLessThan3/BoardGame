using UnityEngine;

public class LoadMenuSceneState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public LoadMenuSceneState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        MenuPlayButton.PlayButtonPressed += LoadMainSeneState;
    }

    public void Enter()
    {
        _sceneLoader.Load("MenuScene");
    }
    private void LoadMainSeneState(int playersValue)
    {
        _stateMachine.EnterState<LoadMainSceneState, int>(playersValue);
    }

    public void Exit()
    {
    }
}