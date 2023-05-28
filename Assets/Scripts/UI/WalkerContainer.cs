using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WalkerContainer : MonoBehaviour
{
    public static event Action SaidThrowGameCubeForReferee;

    [SerializeField]
    private CanvasGroup _canvas;

    [SerializeField]
    private Image _imagePlayer;

    [SerializeField]
    private Button _buttonGiveMoving;

    private void Awake()
    {
        ChangerPlayers.PlayerIsActive += CanvasActive;

    }

    public void SayToThrowGameCube()
    {
        _canvas.alpha = 0;
        SaidThrowGameCubeForReferee?.Invoke();
    }

    private void CanvasActive(StaticDataPlayers player)
    {
        _canvas.alpha = 1;
        _imagePlayer.sprite = player.Icon;
    }
}
