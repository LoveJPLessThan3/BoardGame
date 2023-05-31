using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    public static event Action EndGame;
    
    public void ClickEndGameButton()
    {
        EndGame?.Invoke();
    }
}
