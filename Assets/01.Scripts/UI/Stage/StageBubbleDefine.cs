using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StageBubbleDefine : MonoBehaviour
{
    private readonly string _stageDataSaveKey = "NOGAMENOLIFE";

    private void OnEnable()
    {
        if(DataManager.Instance.IsHaveData(_stageDataSaveKey))
        {
            StageManager.Instance.stageData = DataManager.Instance.LoadData<StageData>(_stageDataSaveKey);
        }

        StageManager.Instance.GenerateData();
        StageBossPanel[] stagePanelArr = FindObjectsOfType<StageBossPanel>();
        foreach(StageBossPanel sbp in stagePanelArr)
        {
            sbp.SetStageStage(StageManager.Instance.GetStageState(sbp.StageIdx));
        }
        DataManager.Instance.SaveData(StageManager.Instance.stageData, _stageDataSaveKey);
    }
}
