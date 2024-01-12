using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireDefine;
using System;

[System.Serializable]
public class FireData
{
    public FireType fireType;
    public int health;
    public float damage;
}

public class FireManager : MonoBehaviour
{
    private static FireManager _instance;
    public static FireManager Instanace
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<FireManager>();
            if (_instance == null)
            {
                Debug.LogError("Not Exist GameManager");
            }
            return _instance;
        }
    }

    #region FireInfo
    [SerializeField] private FireData[] _fireInfoArr = new FireData[(int)Enum.GetValues(typeof(FireType)).Length];
    #endregion

    private Dictionary<FireType, FireData> _fireDataBase = new Dictionary<FireType, FireData>();

    private void Awake()
    {
        foreach(FireData data in _fireInfoArr)
        {
            _fireDataBase.Add(data.fireType, data);
        }    
    }

    public FireData GetFireData(FireType ft)
    {
        if(_fireDataBase.ContainsKey(ft))
        {
            return _fireDataBase[ft];
        }
        Debug.LogError("There is no key in [FireDataBase] Plz Check");
        return new FireData();
    }
}
