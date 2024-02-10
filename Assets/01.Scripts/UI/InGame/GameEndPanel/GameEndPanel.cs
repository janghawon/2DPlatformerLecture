using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] private Image _blackPanel;
    [SerializeField] private Transform _infoPanel;

    private void Start()
    {
        PlayerState.canMove = false;
        PlayerState.canShoot = false;

        _blackPanel.DOFade(0.3f, 0.2f);
        _infoPanel.transform.DOLocalMoveY(0, 0.2f);
    }
}
