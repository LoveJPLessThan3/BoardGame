using UnityEngine;

public class GameBootstrap : MonoBehaviour, ICourutineRunner
{
    private Game _game;

    [SerializeField]
    private LoadingCurtain _curtain;

    private void Awake()
    {
        _game = new Game(this, _curtain);

        _game.StateMachine.EnterState<BootStrapState>();
        DontDestroyOnLoad(this);
    }

}
