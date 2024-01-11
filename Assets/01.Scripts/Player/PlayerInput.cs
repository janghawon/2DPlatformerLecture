using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputReader _reader;

    [Header("클래스 참조는 역시 이벤트지~")]
    [SerializeField] private UnityEvent<Vector2> _movementEvent = null;
    [SerializeField] private UnityEvent _jumpEvent;
    [SerializeField] private UnityEvent _shootEvent;

    private void Start()
    {
        _reader.jumpActon = null;
        _reader.jumpActon += OnJump;
    }

    private void OnJump()
    {
        _jumpEvent?.Invoke();
    }

    private void Update()
    {
        _movementEvent?.Invoke(_reader.movementDirection);
    }
}
