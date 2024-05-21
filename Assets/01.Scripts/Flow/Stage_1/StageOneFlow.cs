using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIDefine;
using DG.Tweening;
using System;

public class StageOneFlow : GameFlowSetter
{
    protected override void StartGameFlow()
    {
        StartCoroutine(GameStartCo());
    }

    private IEnumerator GameStartCo()
    {
        MainBoldText mainBold = FindObjectOfType<MainBoldText>();
        WarnningTape warnTape = FindObjectOfType<WarnningTape>();
        BigFireBossFire bossFire = FindObjectOfType<BigFireBossFire>();
        BossManagement bossManagement = FindObjectOfType<BossManagement>();
        SoundManager.Instanace.PlayBgm(SoundDefine.BGMType.Stage_1);

        mainBold.UpdateBoldText("REMEMBER", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("ONLY", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("ONE THING", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("EXTINGUISH.", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText(Direction.UP, Ease.InBack);
        warnTape.ActiveTape(true);

        PlayerState.isDie = false;
        PlayerState.canJump = true;
        PlayerState.canMove = true;
        PlayerState.canShoot = true;

        bossFire.Active(true);

        Transform bossBarTrm = GameObject.Find("BossFire/HPBarPos").transform;
        bossManagement.SettingBossHpBar(bossBarTrm, UIManager.Instanace.canvasTrm, bossFire);
    }
}
