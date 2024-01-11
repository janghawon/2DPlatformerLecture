using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/Setting/InputReader")]
public class InputReader : ScriptableObject, Controls.IPlayerActions
{
    public Action jumpActon;
    public bool isShooting;
    public Action shootingEndAction;
    public Vector2 movementDirection;
    private Controls _controls;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();

            _controls.Player.SetCallbacks(this);
        }

        _controls.Player.Enable();
    }

    public void DisablePlayer()
    {
        _controls.Player.Disable();
    }
    public void EnablePlayer()
    {
        _controls.Player.Enable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        isShooting = context.performed;
        if(context.canceled)
        {
            shootingEndAction?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumpActon?.Invoke();
    }
}
