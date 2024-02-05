using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireDefine;
using DG.Tweening;

public class Fire : MonoBehaviour
{
    [Header("참조")]
    [SerializeField] private SpriteRenderer[] _fireRenderer;
    [SerializeField] private Collider2D _collider;

    [Header("값")]
    [SerializeField] private FireType _myFireType;
    public FireType MyFireType => _myFireType;
    [SerializeField] private Transform _fireOrigin;
    [SerializeField][Range(1, 10)] private float _hotDistance;
    private Transform _player => GameManager.Instanace.Player;
    [SerializeField] private float _fadeTime;

    private int _maxHealth;
    private int _health;
    private float _tickDamage;
    private Color _baseColor;

    [Header("상태")]
    private bool _isSuppressed;
    private float _currentTime;

    private void Start()
    {
        FireData myData = FireManager.Instanace.GetFireData(_myFireType);
        _health = myData.health;
        _maxHealth = _health;
        _tickDamage = myData.damage;

        for(int i = 0; i< _fireRenderer.Length; i++)
            _baseColor = _fireRenderer[i].color;
    }

    public void GetDamage()
    {
        if (_isSuppressed) return;

        _health--;

        if(_health <= 0)
        {
            _isSuppressed = true;
            BeSuppressed();
        }
    }
    private void BeSuppressed()
    {
        _collider.enabled = false;
        for (int i = 0; i < _fireRenderer.Length; i++)
            _fireRenderer[i].DOFade(0, 0.4f).OnComplete(()=>Destroy(gameObject));
    }

    private void Update()
    {
        if(IsInTick())
        {
            SetDamage();
        }
    }

    private bool IsInTick()
    {
        if (Vector2.Distance(_player.position, _fireOrigin.position) > _hotDistance) return false;

        _currentTime += Time.deltaTime;
        if(_currentTime >= 1)
        {
            _currentTime = 0;
            return true;
        }
        return false;
    }

    private void SetDamage()
    {
        Debug.Log(_tickDamage);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_fireOrigin.position, _hotDistance);
    }
#endif
}
