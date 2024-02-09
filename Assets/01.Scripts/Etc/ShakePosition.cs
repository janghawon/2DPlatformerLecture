using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakePosition : MonoBehaviour
{
    [SerializeField] private float _str;
    [SerializeField] private int _vib;
    private Tween _shakeTween;

    void Start()
    {
        _shakeTween = transform.DOShakePosition(0.1f, _str, _vib).SetLoops(-1);
    }

    private void OnDisable()
    {
        _shakeTween.Kill();
    }
}
