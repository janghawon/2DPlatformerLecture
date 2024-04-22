using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieProcess : MonoBehaviour
{
    public void ResetStage()
    {
        UIManager.Instanace.ChangeUIScreen(UIDefine.UIScreenType.inGame);
        StageManager.Instance.ResetStage();
    }

    public void InitPlayer()
    {
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
