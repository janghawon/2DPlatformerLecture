using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigid;
    [HideInInspector] public float movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _layerMask;
    private Vector2 moveValue;

    public void HandleSetValue(Vector2 value, float speed)
    {
        movementSpeed = speed;
        moveValue = value;
    }

    public void HandleOnJump()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.1f, _layerMask))
        {
            _rigid.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1.1f, new Color(0, 1, 0));

        if (PlayerState.canMove)
            transform.position += (Vector3)moveValue * movementSpeed;
    }
}
