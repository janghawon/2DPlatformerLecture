using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UIDefine;
using DG.Tweening;

public class TapeObject : MonoBehaviour
{
    [SerializeField] private Direction _direction;

    [SerializeField] private TextMeshProUGUI[] _texts = new TextMeshProUGUI[3];

    private void Update()
    {
        for(int i = 0; i < _texts.Length; i++)
        {
            if(_direction == Direction.LEFT)
            {
                _texts[i].transform.localPosition += new Vector3(-1, 0, 0);
                if (_texts[i].transform.localPosition.x <= -1200)
                {
                    _texts[i].transform.localPosition = new Vector3(1200, 0, 0);
                }
            }
            else
            {
                _texts[i].transform.localPosition += new Vector3(1, 0, 0);
                if (_texts[i].transform.localPosition.x >= 1200)
                {
                    _texts[i].transform.localPosition = new Vector3(-1200, 0, 0);
                }
            }
        }
    }
}
