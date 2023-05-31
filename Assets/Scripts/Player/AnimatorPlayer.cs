using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    private static int Walk = Animator.StringToHash("Walk");
    private static int Idle = Animator.StringToHash("Idle");
    private static int Win = Animator.StringToHash("Win");

    private Animator _animator;

    private void Awake() => 
        _animator = GetComponent<Animator>();

    public void PlayIdle() =>
        _animator.SetTrigger(Idle);

    public void PlayWalk() =>
        _animator.SetTrigger(Walk);

    public void PlayWin() =>
        _animator.SetTrigger(Win);
    
}
