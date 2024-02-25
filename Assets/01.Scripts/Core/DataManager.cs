using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    private static DataManager _instnace;
    public static DataManager Instance
    {
        get
        {
            if(_instnace != null)
            {
                return _instnace;
            }

            _instnace = FindObjectOfType<DataManager>();
            return _instnace;
        }
    }

    private List<string> _datakeyList = new List<string>();
    private readonly string _dataKeyFilePath = Path.Combine(Application.dataPath, "DataKeys.json");

    private void Awake()
    {
        if (File.Exists(_dataKeyFilePath))
        {
            string[] keyArr = File.ReadAllText(_dataKeyFilePath).Split(",");
            int saveFileCount = keyArr.Length - 1;

            for (int i = 0; i < saveFileCount; i++)
            {
                _datakeyList.Add(keyArr[i]);
            }
        }
    }

    public void SaveData(CanSaveData saveData, string dataKey)
    {
        if (!IsHaveData(dataKey))
        {
            string prevData = "";
            if (File.Exists(_dataKeyFilePath))
            {
                prevData = File.ReadAllText(_dataKeyFilePath);
            }
            string saveKey = prevData + $"{dataKey},";

            File.WriteAllText(_dataKeyFilePath, saveKey);
            _datakeyList.Add(dataKey);
        }

        File.WriteAllText(GetFilePath(dataKey), JsonUtility.ToJson(saveData));
    }

    public T LoadData<T>(string dataKey) where T : CanSaveData
    {
        if (!IsHaveData(dataKey))
        {
            Debug.LogWarning($"Error! No exist data key!! Key name : {dataKey}");
            return default(T);
        }
        return JsonUtility.FromJson<T>(File.ReadAllText(GetFilePath(dataKey)));
    }

    public bool IsHaveData(string dataKey)
    {
        return _datakeyList.Contains(dataKey);
    }

    private string GetFilePath(string dataKey)
    {
        return Path.Combine(Application.dataPath, $"{dataKey}.json");
    }
}
