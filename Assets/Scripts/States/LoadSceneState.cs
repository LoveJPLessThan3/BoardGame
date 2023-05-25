using Unity.VisualScripting;
using UnityEngine;

public class LoadSceneState : MonoBehaviour, IState
{
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactoryService _gameFactory;

    public LoadSceneState(StateMachine stateMachine, SceneLoader sceneLoader, IGameFactoryService gameFactory)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _gameFactory = gameFactory;
    }

    public void Enter()
    {
        _sceneLoader.Load("MainScene", CreateObjects);
        
    }

    private void CreateObjects()
    {
        _gameFactory.CreatePoints();
        _gameFactory.CreatePerson();
    }

    public void Exit()
    {
    }
}
