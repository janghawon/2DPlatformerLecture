using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterLaser : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _rayTrm;
    [SerializeField] private Transform _laserTrm;
    private Vector2 _dir;

    [SerializeField] private UnityEvent<bool, Vector2, Vector2> _splashEvent;
    [SerializeField] private UnityEvent<bool, Vector2> _ashEvent;

    private void Start()
    {
        _reader.shootingEndAction += ShootEnd;
    }

    private void ShootEnd()
    {
        _splashEvent?.Invoke(false, Vector2.zero, Vector2.zero);
        _ashEvent?.Invoke(false, Vector2.zero);
    }

    public void SetDir(Vector2 value)
    {
        _dir = value;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rayTrm.position, _dir, 20, _layerMask);
        if (hit.collider != null)
        {
            #region 레이저 길이 계산
            Debug.Log(hit.collider);
            Vector2 first = _laserTrm.position;
            Vector2 second = hit.point;

            float length = Mathf.Sqrt(Mathf.Pow(second.x - first.x, 2) + Mathf.Pow(second.y - first.y, 2));
            _laserTrm.localScale = new Vector3(_laserTrm.localScale.x,
                                               _laserTrm.localScale.y,
                                               length * 0.3f);
            #endregion

            if (hit.collider.CompareTag("Ground"))
            {
                _ashEvent?.Invoke(false, second);
                _splashEvent?.Invoke(true, second, _dir);
            }
            else if(hit.collider.CompareTag("Fire"))
            {
                _splashEvent?.Invoke(false, second, _dir);
                _ashEvent?.Invoke(true, second);
            }
        }
        else
        {
            _laserTrm.localScale = new Vector3(_laserTrm.localScale.x,
                                               _laserTrm.localScale.y,
                                               5);
        }

        Debug.DrawRay(_rayTrm.position, _dir * 3, Color.red);
    }
}
