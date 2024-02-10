using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class GameEndButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _filterImage;
    [SerializeField] private Image _filterTextImage;

    private Tween _panelSetupTween;
    private Tween _panelInitTween;

    private Tween _textSetupTween;
    private Tween _textInitTween;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _panelInitTween.Kill();
        _textInitTween.Kill();

        _panelSetupTween = DOTween.To(() => _filterImage.fillAmount,
                      f => _filterImage.fillAmount = f, 1, 0.5f).
                      SetEase(Ease.InQuint);

        _textSetupTween = DOTween.To(() => _filterTextImage.fillAmount,
                      f => _filterTextImage.fillAmount = f, 0, 0.5f).
                      SetEase(Ease.InQuint);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _panelSetupTween.Kill();
        _textSetupTween.Kill();

        _panelInitTween = DOTween.To(() => _filterImage.fillAmount,
                     f => _filterImage.fillAmount = f, 0, 0.5f).
                     SetEase(Ease.InQuint);

        _textInitTween = DOTween.To(() => _filterTextImage.fillAmount,
                     f => _filterTextImage.fillAmount = f, 1, 0.5f).
                     SetEase(Ease.InQuint);

    }
}
