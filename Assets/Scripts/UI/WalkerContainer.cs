using System;
using UnityEngine;
using UnityEngine.UI;

public class WalkerContainer : MonoBehaviour
{
    public static event Action SaidThrowGameCubeForReferee;

    private static readonly int Show = Animator.StringToHash("Show");
    private static readonly int Hide = Animator.StringToHash("Hide");

    [SerializeField]
    private CanvasGroup _canvas;
    [SerializeField]
    private Image _imagePlayer;
    [SerializeField]
    private Button _buttonGiveMoving;
    [SerializeField]
    private Animator _animator;

    private void Awake()
    {
        ChangerPlayers.PlayerIsActive += CanvasActive;
    }

    private void OnDestroy()
    {
        ChangerPlayers.PlayerIsActive -= CanvasActive;
    }

    //кнопка триггерит бросок кубика
    public void SayToThrowGameCube()
    {
        SaidThrowGameCubeForReferee?.Invoke();
        _animator.SetTrigger(Hide);
    }

    //устанавливаем иконку активного плэеера
    private void CanvasActive(StaticDataPlayers player)
    {
        _imagePlayer.sprite = player.Icon;
        _animator.SetTrigger(Show);
    }
}
