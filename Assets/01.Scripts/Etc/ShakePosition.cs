using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakePosition : MonoBehaviour
{
    [SerializeField] private float _str;
    [SerializeField] private int _vib;
    void Start()
    {
        transform.DOShakePosition(0.1f, _str, _vib).SetLoops(-1);
    }
}
