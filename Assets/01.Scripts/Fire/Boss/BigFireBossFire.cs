using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BigFireBossFire : Fire
{
    [SerializeField] private float _destinationX;
    [SerializeField] private Transform _visualTrm;

    private Tween _shakeTween;
    private Tween _moveTween;

    private void Awake()
    {
        transform.localScale = new Vector3(1, 0, 1);
    }

    public void Active(bool isActive)
    {
        _visualTrm.gameObject.SetActive(isActive);
        if(isActive)
        {
            transform.DOScaleY(1, 0.3f).SetEase(Ease.InOutBounce).OnComplete(()=>StartChase());
        }
    }

    private void StartChase()
    {
        _shakeTween = _visualTrm.DOShakePosition(0.2f, 0.5f, 3).SetLoops(-1);
        _moveTween = transform.DOMoveX(_destinationX, 60);
    }

    private void OnDestroy()
    {
        _shakeTween.Kill();
        _moveTween.Kill();

        StageManager.Instance.ClearStage(UIManager.Instanace.canvasTrm);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Fire"))
        {
            _health = _maxHealth;
        }
    }
}
