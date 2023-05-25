using System;
using System.Collections.Generic;

public class StateMachine
{
    private SceneLoader _sceneLoader;
    private Dictionary<Type, IState> _states;

    private IState _activeState;

    public StateMachine(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;

        _states = new Dictionary<Type, IState>()
        {
            [typeof(BootStrapState)] = new BootStrapState(this),
            [typeof(LoadSceneState)] = new LoadSceneState(this, _sceneLoader, ServiceLocator.Instantiate.GetService<IGameFactoryService>()),
        };
    }

    public void EnterState<TState>() where TState : class,IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    private IState ChangeState<TState>() where TState : class,IState
    {
        _activeState?.Exit();
        TState state = GetState<TState>();
        _activeState = state;
        return state;
    }

    private TState GetState<TState>() where TState : class, IState =>
        _states[typeof(TState)] as TState;
}
