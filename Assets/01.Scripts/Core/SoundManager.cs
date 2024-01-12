using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


}
