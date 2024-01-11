using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGun : MonoBehaviour
{
    public void HandleGunShoot()
    {
        Vector3 dir = GameManager.Instanace.GetMousePos() - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
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
