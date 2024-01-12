using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Vector2 _movePos;
    [SerializeField] private Vector2 _idleArmPos;
    [SerializeField] private GameObject _playerArm;

    public void ActiveArm(bool isActive, bool isMove)
    {
        _playerArm.SetActive(isActive);
        _playerArm.transform.localPosition = isMove ? _movePos : _idleArmPos;
        FeedbackManager.Instanace.ShakeScreen(0.05f, 0.1f);
    }
}
