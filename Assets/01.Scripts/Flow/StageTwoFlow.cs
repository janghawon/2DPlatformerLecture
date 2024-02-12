using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTwoFlow : GameFlowSetter
{
    protected override void StartGameFlow()
    {
        PlayerState.canMove = true;
        PlayerState.canJump = true;
    }

}
