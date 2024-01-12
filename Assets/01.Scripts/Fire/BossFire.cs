using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossFire : MonoBehaviour
{
    [SerializeField] private float _destinationX;
    [SerializeField] private Transform _visualTrm;

    private void Start()
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
        _visualTrm.DOShakePosition(0.2f, 0.5f, 3).SetLoops(-1);
        transform.DOMoveX(_destinationX, 60);
    }
}
