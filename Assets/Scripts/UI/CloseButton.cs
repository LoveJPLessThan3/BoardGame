using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private CanvasGroup _walkerConteiner;
    public Canvas _canvasPause;

    public void ButtonPauseClick()
    {
        _canvasPause.gameObject.SetActive(true);
        _walkerConteiner.alpha = 0;
        _button.gameObject.SetActive(false);
    }
}
