using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundDefine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instanace
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<SoundManager>();
            if (_instance == null)
            {
                Debug.LogError("Not Exist GameManager");
            }
            return _instance;
        }
    }

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _clipArr;

    public void PlayBgm(BGMType bgm)
    {
        _audioSource.Stop();
        _audioSource.clip = _clipArr[(int)bgm];
        _audioSource.Play();
    }
}