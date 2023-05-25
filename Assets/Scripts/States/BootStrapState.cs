using System;
using UnityEngine;

public class BootStrapState : IState
{
    private readonly StateMachine _stateMachine;

    public BootStrapState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;

        RegisterService();
    }

    public void Enter()
    {


        _stateMachine.EnterState<LoadSceneState>();
    }

    private void RegisterService()
    {
        ServiceLocator.Instantiate.RegisterService<IGameFactoryService>(new GameFactory());
    }

    public void Exit()
    {
    }
}
