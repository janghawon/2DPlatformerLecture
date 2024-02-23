using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshBoss : MonoBehaviour
{
    [Header("벡터 - 로컬포지션 기입")]
    [SerializeField] private Vector2 _bossNormalPos;
    [SerializeField] private Vector2 _handNormalPos;

    [Header("참조")]
    [SerializeField] private Transform _handTrm;
    [SerializeField] private SpriteRenderer _bodyRenderer;

    public void Reset()
    {
        transform.localPosition = _bossNormalPos;
        _handTrm.localPosition = _handNormalPos;
    }

    public void Active(bool isActive)
    {
        if(isActive)
        {
            _bodyRenderer.material.DOFloat(1.5f, "Vector1_E974001A", 2f);
        }
        else
        {

        }
    }


    void Update()
    {
        float xPos = Mathf.Lerp(transform.position.x, GameManager.Instanace.Player.position.x, Time.deltaTime);
        transform.position = new Vector3(xPos, transform.position.y);
    }
}
