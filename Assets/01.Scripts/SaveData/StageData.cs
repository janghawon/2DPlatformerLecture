using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData : CanSaveData
{
    public StageBubbleState chapterOneState = StageBubbleState.canChallenge;
    public StageBubbleState chapterSecondState = StageBubbleState.unDefine;
    public StageBubbleState chapterThirdState = StageBubbleState.unDefine;
    public StageBubbleState chapterFourthState = StageBubbleState.unDefine;
}
