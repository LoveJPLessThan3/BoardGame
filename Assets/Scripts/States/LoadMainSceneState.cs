using System;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class LoadMainSceneState : IPayLoadedState<int>
{

    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IGameFactoryService _gameFactory;

    private int _valuePlayers;

    public LoadMainSceneState(StateMachine stateMachine, SceneLoader sceneLoader, IGameFactoryService gameFactory)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _gameFactory = gameFactory;

        EndGameButton.EndGame += LoadMenuSceneState;
    }
    public void Enter(int valuePlayers)
    {
        _valuePlayers = valuePlayers;
        _sceneLoader.Load("MainScene", CreateObjects);
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
