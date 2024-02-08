using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StageBossPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _myPanelImg;
    [SerializeField] private Image _myLine;
    [SerializeField] private int _stageIdx;
    public int StageIdx => _stageIdx;
    [SerializeField] private UnityEvent<int, bool> _panelActiveEvent;

    [SerializeField] private GameObject[] _stateObjectArr; 

    public void SetStageStage(StageBubbleState state)
    {
        Color selectColor = StageManager.Instance.GetStateColor(state);

        _myPanelImg.color = selectColor;
        _myLine.color = selectColor;

        _myPanelImg.raycastTarget = (state == StageBubbleState.canChallenge);
        for(int i = 0; i < _stateObjectArr.Length; i++)
        {
            _stateObjectArr[i].SetActive(i == (int)state);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _panelActiveEvent?.Invoke(_stageIdx - 1, true);
    }

    public void PanelDown()
    {
        _panelActiveEvent?.Invoke(_stageIdx - 1, false);
    }
}
