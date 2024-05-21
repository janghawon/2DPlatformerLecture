using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    [SerializeField] private Transform _rightHandOrigin;
    [SerializeField] private Transform _leftHandOrigin;
    private Transform _handOrigin;
    [SerializeField] private Transform _warningMark;
    [SerializeField] private GameObject _ashFXObject;
    [SerializeField] private GameObject _fistImpactFX;

    [SerializeField] private Vector2 _attackTurmRange;
    [SerializeField] private float _attackSpeed;

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _fistSpirte;

    [SerializeField] private LookDirectionSensor _lookDirectionSensor;
    public bool CanAttack { get; set; }
    private bool _isAttacking;
    private Vector2 _targetPos;

    private Tween _atkTween;
    private Coroutine _atkCoroutine;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _targetPos = transform.position;
        _lookDirectionSensor.playerLookDirChanged += HandleChangeHandOrigin;
        HandleChangeHandOrigin(true);
        StartCoroutine(StartAttackSequence());
    }

    public void Dead()
    {
        _atkTween.Kill();
        CanAttack = false;
        StopCoroutine(_atkCoroutine);
        gameObject.SetActive(false);
    }

    private void HandleChangeHandOrigin(bool isLookRight)
    {
        if(isLookRight)
        {
            _handOrigin = _leftHandOrigin;
        }
        else
        {
            _handOrigin = _rightHandOrigin;
        }
    }

    private void Update()
    {
        if (_isAttacking || !CanAttack) return;

        if(Vector2.Distance(transform.position, _targetPos) < 0.1f)
        {
            Vector2 randomOffset = Random.insideUnitCircle * 1.1f;
            _targetPos = (Vector2)_handOrigin.position + randomOffset;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, Time.deltaTime * 20);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _isAttacking)
        {
            Debug.Log("°¨Áö");
            collision.gameObject.TryGetComponent<PlayerDie>(out PlayerDie pd);
            pd.CreateResetProcess();
        }
    }

    private IEnumerator StartAttackSequence()
    {
        yield return new WaitForSeconds(3f);
        _atkCoroutine = StartCoroutine(AttackSequenceCorotine());
    }

    private void Attack()
    {
        _isAttacking = true;
        _ashFXObject.SetActive(true);

        Vector2 playerPos = GameManager.Instanace.Player.position;

        Instantiate(_warningMark, playerPos, Quaternion.identity);

        transform.LookAt(-playerPos);
        _atkTween = transform.DOMove(playerPos, _attackSpeed).SetEase(Ease.InBack).
                  OnComplete(() =>
                  {
                      Instantiate(_fistImpactFX, playerPos, Quaternion.identity);
                      _atkCoroutine = StartCoroutine(AttackSequenceCorotine());
                      FeedbackManager.Instanace.ShakeScreen(1, 1f);
                      _ashFXObject.SetActive(false);
                      transform.rotation = Quaternion.identity;
                  });
    }

    IEnumerator AttackSequenceCorotine()
    {
        yield return new WaitForSeconds(0.1f);
        _isAttacking = false;
        yield return new WaitForSeconds(0.2f);
        
        _spriteRenderer.sprite = _normalSprite;
        
        float randomTime = Random.Range(_attackTurmRange.x, _attackTurmRange.y);
        yield return new WaitForSeconds(randomTime);
        
        Attack();
    }
}
