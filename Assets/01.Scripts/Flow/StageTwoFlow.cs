using DG.Tweening;
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

        mainBold.UpdateBoldText("SEARCH", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("AND", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("DESTROY", true);
        yield return new WaitForSeconds(1f);
        mainBold.UpdateBoldText(Direction.UP, Ease.InBack);

        ashBoss.Active(true);
        yield return new WaitForSeconds(2);

        PlayerState.canMove = true;
        PlayerState.canJump = true;
        PlayerState.canShoot = true;

        warnTape.ActiveTape(true);
        upFire.StartUp();
        hand.CanAttack = true;
    }
}
