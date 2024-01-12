using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MCalcualtor
{
    public static int GetPlusOrMinus()
    {
        return (int)Mathf.Sign(Random.Range(0, 2) * 2 - 1);
    }
}
