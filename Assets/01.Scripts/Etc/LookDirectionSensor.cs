using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UIDefine;

public class LookDirectionSensor : MonoBehaviour
{
    private Transform _playerTrm;
    private float _playerXPos;
    public Action<bool> playerLookDirChanged = null;
    private Direction _playerLookDirection = Direction.UP;

    private void Start()
    {
        _playerTrm = FindObjectOfType<PlayerInput>().transform;
        _playerXPos = _playerTrm.position.x;
    }

    private void Update()
    {
        if(_playerTrm.position.x > _playerXPos && _playerLookDirection != Direction.RIGHT) // 왼쪽 보다가 오른쪽 보고 있음
        {
            _playerLookDirection = Direction.RIGHT;
            playerLookDirChanged?.Invoke(true);
        }
        else if(_playerTrm.position.x < _playerXPos && 
                _playerTrm.position.x != _playerXPos && _playerLookDirection != Direction.LEFT)
        {
            _playerLookDirection = Direction.LEFT;
            playerLookDirChanged?.Invoke(false);
        }
        
        _playerXPos = _playerTrm.position.x;
    }
}
