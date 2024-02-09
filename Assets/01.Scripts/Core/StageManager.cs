using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public enum StageBubbleState
{
    canChallenge,
    clear,
    unDefine
}

public class StageManager : MonoBehaviour
{
    private static StageManager _instnace;
    public static StageManager Instance
    {
        get
        {
            if (_instnace != null)
            {
                return _instnace;
            }

            _instnace = FindObjectOfType<StageManager>();
            return _instnace;
        }
    }

    [SerializeField] private Color[] _stageColorArr;
    private Dictionary<StageBubbleState, Color> _getStageColorDic = new Dictionary<StageBubbleState, Color>();
    private Dictionary<int, StageBubbleState> _checkStageTypeDic = new Dictionary<int, StageBubbleState>();
    public StageData stageData = new StageData();

    public int SelectStageIdx { get; set; }
    [SerializeField] private GameObject[] _gameStageArr;

    private void Awake()
    {
        foreach (StageBubbleState state in Enum.GetValues(typeof(StageBubbleState)))
        {
            _getStageColorDic.Add(state, _stageColorArr[(int)state]);
        }

        for(int i = 0; i < 4; i++)
        {
            _checkStageTypeDic.Add(i, StageBubbleState.unDefine);
        }

        SceneManager.sceneLoaded += HandleCreateStage;
    }

    private void HandleCreateStage(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Play")
        {
            Instantiate(_gameStageArr[SelectStageIdx]);
        }
    }

    public void GenerateData()
    {
        _checkStageTypeDic[1] = stageData.chapterOneState;
        _checkStageTypeDic[2] = stageData.chapterSecondState;
        _checkStageTypeDic[3] = stageData.chapterThirdState;
        _checkStageTypeDic[4] = stageData.chapterFourthState;
    }

    public Color GetStateColor(StageBubbleState state)
    {
        return _getStageColorDic[state];
    }

    public StageBubbleState GetStageState(int stageIdx)
    {
        return _checkStageTypeDic[stageIdx];
    }

    public void ClearStage()
    {

    }
}
