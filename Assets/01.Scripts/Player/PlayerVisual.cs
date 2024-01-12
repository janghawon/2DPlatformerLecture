using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerVisual : MonoBehaviour
{
    public void SetFlip(bool isLeft /*true is Look Left, */)
    {
        transform.rotation = Quaternion.Euler(0, 180 * Convert.ToInt32(isLeft), 0);
    }
}
