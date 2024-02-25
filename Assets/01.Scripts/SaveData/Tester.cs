using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private Sprite[] _sampleSpriteArr;
    private TestData td = new TestData();
    private const string dataKey = "TestDataKey";

    private void Start()
    {
        if(DataManager.Instance.IsHaveData(dataKey))
        {
            td = DataManager.Instance.LoadData<TestData>(dataKey);
            foreach(Sprite item in td.testList)
            {
                Debug.Log(item);
            }
        }
        else
        {
            td.EatInt(_sampleSpriteArr);
            DataManager.Instance.SaveData(td, dataKey);

            if(DataManager.Instance.IsHaveData(dataKey))
            {
                Debug.Log("CompleteSaveData");
            }
        }
    }
}
