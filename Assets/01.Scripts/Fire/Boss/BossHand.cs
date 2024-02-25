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

    [SerializeField] private Vector2 _attackTurmRange;
    [SerializeField] private float _attackSpeed;

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _normalSprite;
    [SerializeField] private Sprite _fistSpirte;

    [SerializeField] private LookDirectionSensor _lookDirectionSensor;
    public bool CanAttack { get; set; }
    private bool _isAttacking;
    private Vector2 _targetPos;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _targetPos = transform.position;
        _lookDirectionSensor.playerLookDirChanged += HandleChangeHandOrigin;
        HandleChangeHandOrigin(true);
        StartCoroutine(StartAttackSequence());
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
            Debug.Log("»ç¸Á");
        }
    }

    private IEnumerator StartAttackSequence()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(AttackSequenceCorotine());
    }

    private void Attack()
    {
        _isAttacking = true;
        _spriteRenderer.sprite = _fistSpirte;

        Vector2 playerPos = GameManager.Instanace.Player.position;

        Instantiate(_warningMark, playerPos, Quaternion.identity);

        transform.DOMove(playerPos, _attackSpeed).SetEase(Ease.InBack).
                  OnComplete(() =>
                  {
                      
                      StartCoroutine(AttackSequenceCorotine());
                      FeedbackManager.Instanace.ShakeScreen(1, 1f);
                  });
    }

    IEnumerator AttackSequenceCorotine()
    {
        _isAttacking = false;
        yield return new WaitForSeconds(0.5f);
        _spriteRenderer.sprite = _normalSprite;
        
        float randomTime = Random.Range(_attackTurmRange.x, _attackTurmRange.y);
        yield return new WaitForSeconds(randomTime);
        
        Attack();
    }
}
