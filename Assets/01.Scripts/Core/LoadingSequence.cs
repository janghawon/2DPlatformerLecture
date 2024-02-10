using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LoadingSequence : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadingText;
    [SerializeField] private Image _loadingBar;

    private static LoadingSequence _instance;
    public static LoadingSequence Instanace
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<LoadingSequence>();
            if (_instance == null)
            {
                Debug.LogError("Not Exist LoadingSequence");
            }
            return _instance;
        }
    }

    public void SetLoadingText(string loadingValue)
    {
        _loadingText.text = loadingValue;
    }

    public void SetLoadingBar(float loadingValue)
    {
        _loadingBar.fillAmount = loadingValue;
    }
}
