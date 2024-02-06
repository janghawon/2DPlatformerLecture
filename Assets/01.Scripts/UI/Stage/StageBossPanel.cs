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

    public void SetStageStage(StageBubbleState state)
    {
        Color selectColor = StageManager.Instance.GetStateColor(state);

        _myPanelImg.color = selectColor;
        _myLine.color = selectColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _panelActiveEvent?.Invoke(_stageIdx - 1, true);
    }
}
