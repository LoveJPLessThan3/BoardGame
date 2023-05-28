using System;
using UnityEngine;

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

    public void Enter()
    {


        _stateMachine.EnterState<LoadSceneState>();
    }

    private void RegisterService()
    {
        _serviceLocator.RegisterService<IGameFactoryService>(new GameFactory());
    }

    public void Exit()
    {
    }
}
