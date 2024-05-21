using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningMark : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Sequence seq = DOTween.Sequence();

        seq.Append(sr.DOFade(0, 0.5f));
        seq.Join(transform.DOScale(2, 0.5f));
        seq.AppendCallback(() => Destroy(gameObject));
    }
}
