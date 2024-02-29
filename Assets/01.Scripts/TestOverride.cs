using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOverride : TestBase
{
    [SerializeField] private bool _condition;

    private void Start()
    {
        TestMethod();
    }

    protected override void TestMethod()
    {
        _canCoProgressMore = false;

        Debug.Log("Method Start!");
        base.TestMethod();

        if(_condition)
        {
            _canCoProgressMore = true;
        }
        else
        {
            StopCoroutine(_testCo);
        }
        Debug.Log("Method End!");
    }
}
