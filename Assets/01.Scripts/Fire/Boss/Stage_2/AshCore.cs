using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshCore : Fire
{
    public Action SurpressedAction { get; set; }

    private void OnDestroy()
    {
        SurpressedAction();
    }
}
