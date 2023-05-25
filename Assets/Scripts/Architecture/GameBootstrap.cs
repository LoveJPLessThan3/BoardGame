using System.Collections.Generic;
using UnityEngine;

public class GameBootstrap : MonoBehaviour, ICourutineRunner
{
    private Game _game;
    private void Awake()
    {
        _game = new Game(this);


        _game.StateMachine.EnterState<BootStrapState>();
        DontDestroyOnLoad(this);
    }
}
