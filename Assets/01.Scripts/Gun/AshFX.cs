using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshFX : MonoBehaviour
{
    public void HandleOnAsh(bool value, Vector2 pos)
    {
        gameObject.SetActive(value);
        transform.position = pos;

    }
}
