using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBase : MonoBehaviour
{
    protected bool _canCoProgressMore;
    protected Coroutine _testCo;

    protected virtual void TestMethod()
    {
        _testCo = StartCoroutine(TestCoroutine());
    }

    private IEnumerator TestCoroutine()
    {
        Debug.Log("Corutine Start!");
        yield return new WaitUntil(()=> _canCoProgressMore);
        Debug.Log("Corutine End!");
    }
}
