using System;
using System.Collections.Generic;

public class StateMachine
{
    private SceneLoader _sceneLoader;
    private Dictionary<Type, IExitableState> _states;

    private IExitableState _activeState;

    public StateMachine(SceneLoader sceneLoader, LoadingCurtain curtain)
    {
        _sceneLoader = sceneLoader;

        _states = new Dictionary<Type, IExitableState>()
        {
            [typeof(BootStrapState)] = new BootStrapState(this),
            [typeof(LoadMainSceneState)] = new LoadMainSceneState(this, _sceneLoader, ServiceLocator.Instantiate.GetService<IGameFactoryService>(), curtain),
            [typeof(LoadMenuSceneState)] = new LoadMenuSceneState(this, _sceneLoader, curtain),
        };
    }

    public void EnterState<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    public void EnterState<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
    {

        IPayLoadedState<TPayLoad> state = ChangeState<TState>();
        state.Enter(payLoad);
    }
    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();
        TState state = GetState<TState>();
        _activeState = state;
        return state;
    }
    private TState GetState<TState>() where TState : class, IExitableState =>
        _states[typeof(TState)] as TState;
}
