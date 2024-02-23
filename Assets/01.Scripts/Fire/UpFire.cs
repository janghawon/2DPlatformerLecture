using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpFire : MonoBehaviour
{
    [SerializeField] private Transform _fireTrm;
    [SerializeField] private Vector2 _startPos;
    private Tween _upTween;

    public void StartUp()
    {
        Animator[] upFires = GetComponentsInChildren<Animator>();

        for (int i = 0; i < upFires.Length; i++)
        {
            upFires[i].speed = Random.Range(0.5f, 3.0f);
        }

        //_fireTrm.DOShakePosition(0.3f, 1, 10).SetLoops(-1);
        _upTween = transform.DOMoveY(62, 60f);
    }

    public void ResetPosition()
    {
        transform.position = _startPos;
    }

    public void StopMove()
    {
        _upTween.Kill();
    }
}
