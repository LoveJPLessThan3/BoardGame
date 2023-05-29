using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseContainer : MonoBehaviour
{
    [SerializeField]
    private Canvas _pauseCanvas;
    [SerializeField]
    private CanvasGroup _walkerConteiner;
    [SerializeField]
    private Button _pauseGame;

    public void ResumeGameClick()
    {
        Debug.Log(222);
        _pauseGame.gameObject.SetActive(true);
        _walkerConteiner.alpha = 1;
        _pauseCanvas.gameObject.SetActive(false);
    }

}
