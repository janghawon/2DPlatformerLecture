using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearFlow : MonoBehaviour
{
    [SerializeField] private UpFire _upFire;
    [SerializeField] private AshBoss _ashBoss;
    [SerializeField] private BossHand _bossHand;
    [SerializeField] private CinemachineVirtualCamera _vcam;

    public void ClearStage()
    {
        PlayerState.canMove = false;
        PlayerState.canJump = false;    
        PlayerState.canShoot = false;

        _upFire.StopMove();
        _ashBoss.Active(false);
        _bossHand.Dead();

        _vcam.m_Follow = _ashBoss.transform;
    }
}
