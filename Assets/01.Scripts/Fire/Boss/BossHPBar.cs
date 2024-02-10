using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    [SerializeField] private Slider _hpBarSlider;
    private Transform _followingTrm;
    private Fire _ownerBoss;

    public void SetUp(Transform followingPos, Fire targetBoss)
    {
        _hpBarSlider.value = 1;

        _followingTrm = followingPos;
        _ownerBoss = targetBoss;
    }

    private void Update()
    {
        if (_ownerBoss.IsSuppressed)
        {
            Destroy(gameObject);
            return;
        }

        transform.localPosition = 
            GameManager.Instanace.GetCanvasPos(_followingTrm.position,
                                               UIManager.Instanace.canvasTrm as RectTransform);

        _hpBarSlider.value = _ownerBoss.CurrentHealth / _ownerBoss.MaxHealth;
    }
}
