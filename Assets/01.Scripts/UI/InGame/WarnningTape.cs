using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnningTape : MonoBehaviour
{
    [SerializeField] private TapeObject[] _tapeObjectArr;

    public void ActiveTape(bool isActive)
    {
        for(int i = 0; i < _tapeObjectArr.Length; i++)
        {
            _tapeObjectArr[i].gameObject.SetActive(isActive);
        }
    }
}
