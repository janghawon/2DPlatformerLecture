using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManagement : MonoBehaviour
{
    [SerializeField] private BossHPBar _bossHpBarPrefab;
    private BossHPBar _currentHpBar;

    public void SettingBossHpBar(Transform followingPos, Transform canvasTrm, Fire targetBoss)
    {
        _currentHpBar = Instantiate(_bossHpBarPrefab, canvasTrm);
        _currentHpBar.SetUp(followingPos, targetBoss);
    }

    public void RemoveBossHpBar()
    {
        if(_currentHpBar != null ) 
            Destroy(_currentHpBar.gameObject);
    }
}
