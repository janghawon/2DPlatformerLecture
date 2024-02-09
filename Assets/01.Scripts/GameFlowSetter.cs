using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIDefine;
using DG.Tweening;

public class GameFlowSetter : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GameStartCo());
    }

    IEnumerator GameStartCo()
    {
        MainBoldText mainBold = FindObjectOfType<MainBoldText>();
        WarnningTape warnTape = FindObjectOfType<WarnningTape>();
        BigFireBossFire bossFire = FindObjectOfType<BigFireBossFire>();
        BossManagement bossManagement = FindObjectOfType<BossManagement>();
        SoundManager.Instanace.PlayBgm(SoundDefine.BGMType.Stage_1);

        Transform bossBarTrm = GameObject.Find("BossFire/HPBarPos").transform;

        mainBold.UpdateBoldText("REMEMBER", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("ONLY", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("ONE THING", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText("\"EXTINGUISH\"", true);
        yield return new WaitForSeconds(1f);

        mainBold.UpdateBoldText(Direction.UP, Ease.InBack);
        warnTape.ActiveTape(true);

        PlayerState.canJump = true;
        PlayerState.canMove = true;
        PlayerState.canShoot = true;

        bossFire.Active(true);
        bossManagement.SettingBossHpBar(bossBarTrm, UIManager.Instanace.canvasTrm, bossFire);
    }
}
