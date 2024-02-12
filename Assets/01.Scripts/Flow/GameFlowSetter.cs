using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameFlowSetter : MonoBehaviour
{
    private void Start()
    {
        StartGameFlow();
    }

    protected abstract void StartGameFlow();
}
