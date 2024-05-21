using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUIObject : UIObject
{
    private void Start()
    {
        SoundManager.Instanace.PlayBgm(SoundDefine.BGMType.Lobby);
    }
}
