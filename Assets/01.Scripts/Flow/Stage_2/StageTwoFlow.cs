using DG.Tweening;
using SoundDefine;
using System;
using System.Collections;
using System.Collections.Generic;
using UIDefine;
using UnityEngine;

public class StageTwoFlow : GameFlowSetter
{
    protected override void StartGameFlow()
    {
        StartCoroutine(FameFlowCo());
    }

    IEnumerator FameFlowCo()
    {
        MainBoldText mainBold = FindObjectOfType<MainBoldText>();
        WarnningTape warnTape = FindObjectOfType<WarnningTape>();
        AshBoss ashBoss = FindObjectOfType<AshBoss>();
        UpFire upFire = FindObjectOfType<UpFire>();
        BossHand hand = FindObjectOfType<BossHand>();

        SoundManager.Instanace.PlayBgm(BGMType.Stage_2);

        mainBold.UpdateBoldText("RUN", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("AND", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("KILL", true);
        ashBoss.Active(true);

        yield return new WaitForSeconds(1f);
        mainBold.UpdateBoldText(Direction.UP, Ease.InBack);

        PlayerState.isDie = false;
        PlayerState.canMove = true;
        PlayerState.canJump = true;
        PlayerState.canShoot = true;

        warnTape.ActiveTape(true);
        upFire.StartUp();
        hand.CanAttack = true;
    }
}
