using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UIDefine;

public class MainBoldText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _boldText;
    [SerializeField] private TextMeshProUGUI _shadowText;

    public void UpdateBoldText(string sentence, bool isShaking)
    {
        _boldText.transform.localPosition = Vector3.zero;
        _shadowText.transform.localPosition = Vector3.zero;

        _boldText.text = sentence;
        _shadowText.text = sentence;

        if(isShaking)
        {
            _boldText.transform.DOShakePosition(0.3f, 80, 80);
            _shadowText.transform.DOShakePosition(0.3f, 80, 80);
        }
    }

    public void UpdateBoldText(Direction dir, Ease ease)
    {
        Sequence seq = DOTween.Sequence();
        switch (dir)
        {
            case Direction.UP:
                {
                    seq.Append(_boldText.transform.DOLocalMoveY(730, 0.3f).SetEase(ease));
                    seq.Join(_shadowText.transform.DOLocalMoveY(730, 0.3f).SetEase(ease));
                }
                break;
            case Direction.DOWN:
                break;
            case Direction.LEFT:
                break;
            case Direction.RIGHT:
                break;
        }
    }

}
