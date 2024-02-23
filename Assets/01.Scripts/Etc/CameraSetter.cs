using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    [SerializeField] private Transform _vCamera;
    [SerializeField] private float _rotValue;
    [SerializeField] private LookDirectionSensor _lookDirectionSensor;

    private void Start()
    {
        _lookDirectionSensor.playerLookDirChanged += HandleChangedPlayerLook;
    }

    private void HandleChangedPlayerLook(bool isLookRight)
    {
        if(isLookRight)
            _vCamera.DORotateQuaternion(Quaternion.Euler(0, 0, -_rotValue), 0.2f);
        else
            _vCamera.DORotateQuaternion(Quaternion.Euler(0, 0, _rotValue), 0.2f);
    }
}
