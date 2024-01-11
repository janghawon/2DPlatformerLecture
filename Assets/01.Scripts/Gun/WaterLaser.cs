using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLaser : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _rayTrm;
    [SerializeField] private Transform _laserTrm;
    [SerializeField] private GameObject _splash;
    private Vector2 _dir;

    public void SetDir(Vector2 value)
    {
        _dir = value;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rayTrm.position, _dir, 20, _layerMask);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider);
            Vector2 first = _laserTrm.position;
            Vector2 second = hit.point;

            float length = Mathf.Sqrt(Mathf.Pow(second.x - first.x, 2) + Mathf.Pow(second.y - first.y, 2));
            _laserTrm.localScale = new Vector3(_laserTrm.localScale.x,
                                               _laserTrm.localScale.y,
                                               length * 0.3f);
            _splash.SetActive(true);
            _splash.transform.position = second;
            _splash.transform.localRotation = Quaternion.Euler(_dir);
        }
        else
        {
            _laserTrm.localScale = new Vector3(_laserTrm.localScale.x,
                                               _laserTrm.localScale.y,
                                               5);
            _splash.SetActive(false);
        }

        

        Debug.DrawRay(_rayTrm.position, _dir * 3, Color.red);
    }
}
