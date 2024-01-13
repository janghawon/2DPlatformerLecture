using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshFX : MonoBehaviour
{
    public void HandleOnAsh(bool value, Vector2 pos, Vector2 rot)
    {
        gameObject.SetActive(value);
        transform.position = pos;
        transform.localRotation = Quaternion.Euler(rot);
    }
}
