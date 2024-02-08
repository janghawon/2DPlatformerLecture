using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class LookInfoPanel : MonoBehaviour
{
    [SerializeField] private Image _backPanel;
    [SerializeField] private Transform[] _infoPanelArr;

    public void HandleActivePanel(int idx, bool value)
    {
        if (value)
        {
            _backPanel.raycastTarget = true;
            _backPanel.DOFade(0.2f, 0.2f);
            _infoPanelArr[idx].gameObject.SetActive(true);
            _infoPanelArr[idx].DOLocalMoveY(0, 0.2f);
        }
        else
        {
            _backPanel.raycastTarget = false;
            _backPanel.DOFade(0, 0.2f);
            _infoPanelArr[idx].DOLocalMoveY(-1000, 0.2f).
                               OnComplete(() => _infoPanelArr[idx].gameObject.SetActive(false));
        }
    }
}