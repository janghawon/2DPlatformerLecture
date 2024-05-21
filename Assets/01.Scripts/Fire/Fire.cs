using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireDefine;
using DG.Tweening;
using UnityEngine.Events;

public class Fire : MonoBehaviour
{
    [Header("참조")]
    [SerializeField] private SpriteRenderer[] _fireRenderer;
    [SerializeField] private Collider2D _collider;

    [Header("값")]
    [SerializeField] private FireType _myFireType;
    public FireType MyFireType => _myFireType;
    [SerializeField] protected Transform _fireOrigin;
    [SerializeField][Range(1, 10)] protected float _hotDistance;
    private Transform _player => GameManager.Instanace.Player;
    [SerializeField] private float _fadeTime;

    protected float _maxHealth;
    protected float _health;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _health;

    private Color _baseColor;

    [Header("상태")]
    private bool _isSuppressed;
    public bool IsSuppressed => _isSuppressed;
    private float _currentTime;

    [SerializeField] private UnityEvent _fireSuppressedEvent;

    private void Start()
    {
        FireData myData = FireManager.Instanace.GetFireData(_myFireType);
        _health = myData.health;
        _maxHealth = _health;

        for (int i = 0; i < _fireRenderer.Length; i++)
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

    public void BeSuppressed()
    {
        _collider.enabled = false;
        for (int i = 0; i < _fireRenderer.Length; i++)
        {
            Tween fadeTween = _fireRenderer[i].DOFade(0, 0.4f);
            if(i == _fireRenderer.Length - 1)
            {
                fadeTween.OnComplete(() =>
                {
                    _fireSuppressedEvent?.Invoke();
                    Destroy(gameObject);
                });
            }
        }
    }

    private void Update()
    {
        if(IsInRange())
        {
            PlayerDie pd = _player.GetComponent<PlayerDie>();
            pd.CreateResetProcess();
            PlayerState.isDie = true;
        }
    }

    private bool IsInRange()
    {
        if (Vector2.Distance(_player.position, _fireOrigin.position) > _hotDistance) return false;

        _currentTime += Time.deltaTime;
        if(_currentTime >= 0.2f)
        {
            _currentTime = 0;
            return true;
        }
        return false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_fireOrigin.position, _hotDistance);
    }
#endif
}
