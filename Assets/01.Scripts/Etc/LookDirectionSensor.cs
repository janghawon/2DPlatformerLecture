using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LookDirectionSensor : MonoBehaviour
{
    private Transform _playerTrm;
    private float _playerXPos;
    public Action<bool> playerLookDirChanged = null;
    private bool _playerLookRight = true;

    private void Start()
    {
        _playerTrm = GameManager.Instanace.Player;
    }

    private void Update()
    {
        if(_playerTrm.position.x > _playerXPos && !_playerLookRight) // 왼쪽 보다가 오른쪽 보고 있음
        {
            _playerLookRight = true;
            playerLookDirChanged?.Invoke(true);
        }
        else if(_playerTrm.position.x < _playerXPos && 
                _playerTrm.position.x != _playerXPos && _playerLookRight)
        {
            _playerLookRight= false;
            playerLookDirChanged?.Invoke(false);
        }
        
        _playerXPos = _playerTrm.position.x;
    }
}
