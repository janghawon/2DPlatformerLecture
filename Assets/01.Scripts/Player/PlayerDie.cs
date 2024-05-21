using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] private GameObject _gameResetProcess;

    public void CreateResetProcess()
    {
        if (PlayerState.isDie) return;

        BossManagement bm = FindObjectOfType<BossManagement>();
        bm.RemoveBossHpBar();
        Instantiate(_gameResetProcess, UIManager.Instanace.canvasTrm);
    }
}
