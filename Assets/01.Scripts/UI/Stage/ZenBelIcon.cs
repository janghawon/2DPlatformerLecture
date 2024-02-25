using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZenBelIcon : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Color _frontColor;
    [SerializeField] private Color _backColor;

    private Sequence _colorChangeSeq;

    private void Start()
    {
        _icon.DOColor(_frontColor, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _colorChangeSeq.Kill();
    }
}
