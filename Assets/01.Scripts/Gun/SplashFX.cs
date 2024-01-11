using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashFX : MonoBehaviour
{
    public void HandleOnSplash(bool value, Vector2 pos, Vector2 dir)
    {
        gameObject.SetActive(value);
        transform.position = pos;
        transform.localRotation = Quaternion.Euler(dir);
    }
}
