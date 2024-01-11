using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputReader _reader;

    [Header("클래스 참조는 역시 이벤트지~")]
    [SerializeField] private UnityEvent<Vector2> _movementEvent = null;
    [SerializeField] private UnityEvent<bool> _flipEvent;
    [SerializeField] private UnityEvent<bool> _moveAnimaEvent;
    [SerializeField] private UnityEvent _jumpEvent;
    [SerializeField] private UnityEvent<bool, bool> _shootEvent;

    private void Start()
    {
        _reader.jumpActon = null;
        _reader.jumpActon += OnJump;
        _reader.shootingEndAction = null;
        _reader.shootingEndAction += OutShoot;
    }

    private void OnJump()
    {
        _jumpEvent?.Invoke();
    }

    private void OutShoot()
    {
        _shootEvent?.Invoke(false, false);
    }

    private void Update()
    {
        _movementEvent?.Invoke(_reader.movementDirection);

        bool isMove = _reader.movementDirection.x != 0;
        _moveAnimaEvent?.Invoke(isMove);
        
        if (isMove)
        {
            _flipEvent?.Invoke(_reader.movementDirection.x < 0);
        }

        if (_reader.isShooting)
        {
            _flipEvent?.Invoke(transform.InverseTransformPoint(GameManager.Instanace.GetMousePos()).x < 0);
            _shootEvent?.Invoke(true, isMove);
        }
    }
}
