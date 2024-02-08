using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    private static BossManager _instance;
    public static BossManager Instanace
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<BossManager>();
            if (_instance == null)
            {
                Debug.LogError("Not Exist BossManager");
            }
            return _instance;
        }
    }

    [SerializeField] private BossHPBar _bossHpBarPrefab;

    public void SettingBossHpBar(Transform followingPos, Transform canvasPos, Fire targetBoss)
    {
        BossHPBar hpBar = Instantiate(_bossHpBarPrefab, canvasPos);
        hpBar.SetUp(followingPos, targetBoss);
    }
}
