using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManagement : MonoBehaviour
{
    [SerializeField] private BossHPBar _bossHpBarPrefab;

    public void SettingBossHpBar(Transform followingPos, Transform canvasTrm, Fire targetBoss)
    {
        BossHPBar hpBar = Instantiate(_bossHpBarPrefab, canvasTrm);
        hpBar.SetUp(followingPos, targetBoss);
    }
}
