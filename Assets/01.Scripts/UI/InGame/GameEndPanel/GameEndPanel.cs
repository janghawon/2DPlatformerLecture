using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] private Image _blackPanel;

    private void Start()
    {
        _blackPanel.DOFade(0.3f, 0.2f);
    }
}
