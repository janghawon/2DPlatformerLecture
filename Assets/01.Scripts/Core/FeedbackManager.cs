using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FeedbackManager : MonoBehaviour
{
    private static FeedbackManager _instance;
    public static FeedbackManager Instanace
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<FeedbackManager>();
            if (_instance == null)
            {
                Debug.LogError("Not Exist GameManager");
            }
            return _instance;
        }
    }

    private CinemachineImpulseSource _impulseSource;

    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void ShakeScreen(float shakeValue, float shakeTime)
    {
        Vector3 shakeVelocity = 
        new Vector3(MCalcualtor.GetPlusOrMinus() * shakeValue, MCalcualtor.GetPlusOrMinus() * shakeValue);
        _impulseSource.GenerateImpulse(shakeVelocity);
    }
}
