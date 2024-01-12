using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigid;
    public float movementSpeed;
    [SerializeField] private float _jumpForce;
    private Vector2 moveValue;

    public void HandleSetValue(Vector2 value, float speed)
    {
        movementSpeed = speed;
        moveValue = value;
    }

    public void HandleOnJump()
    {
        _rigid.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)moveValue * movementSpeed;
    }
}
