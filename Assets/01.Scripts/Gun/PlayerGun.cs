using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> _dirSetEvent;

    public void HandleGunShoot()
    {
        Vector3 dir = GameManager.Instanace.GetMousePos() - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        _dirSetEvent?.Invoke(dir);
        if(angle >= 90 || angle <= -90)
        {
            angle = -angle;
            transform.localRotation = Quaternion.Euler(180, 180, angle);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void Update()
    {
        HandleGunShoot();
    }
}
