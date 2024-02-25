using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestData : CanSaveData
{
    public void EatInt(Sprite[] getArr)
    {
        for(int i = 0; i < getArr.Length; i++)
        {
            testList.Add(getArr[i]);
        }
    }

    public List<Sprite> testList = new List<Sprite>();
}
