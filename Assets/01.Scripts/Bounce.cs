using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float _bouncingTurm;
    [SerializeField] private float _bouncingValue;

    private Tween _bouncingTween;

    private void Start()
    {
        float normalY = transform.position.y;

        _bouncingTween = 
        transform.DOMoveY(normalY + _bouncingValue, _bouncingTurm).
        SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _bouncingTween.Kill();
    }
}
