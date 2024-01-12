using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMove _playerMove;

    private readonly int _playerMoveHash = Animator.StringToHash("isRun");
    private readonly int _playerShootHash = Animator.StringToHash("isShoot");

    public void SetMoveAnimation(bool value)
    {
        _animator.SetBool(_playerMoveHash, value);
        
        if(value)
        {
            _animator.speed = _playerMove.movementSpeed * 5;
        }
    }

    public void OnShootAnimaton(bool value, bool value2)
    {
        _animator.SetBool(_playerShootHash, value);
    }

}
