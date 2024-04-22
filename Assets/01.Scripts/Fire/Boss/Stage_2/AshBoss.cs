using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshBoss : MonoBehaviour
{
    [Header("���� - ���������� ����")]
    [SerializeField] private Vector2 _bossNormalPos;
    [SerializeField] private Vector2 _handNormalPos;

    [Header("����")]
    [SerializeField] private Transform _handTrm;
    [SerializeField] private SpriteRenderer _bodyRenderer;
    [SerializeField] private Sprite _dieSprite;

    private bool _isDead;

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
            _isDead = true;
            _bodyRenderer.sprite = _dieSprite;
            _bodyRenderer.material.DOFloat(-1.5f, "Vector1_E974001A", 2f);
        }
    }

    void Update()
    {
        if (_isDead) return;

        float xPos = Mathf.Lerp(transform.position.x, GameManager.Instanace.Player.position.x, Time.deltaTime);
        transform.position = new Vector3(xPos, transform.position.y);
    }
}