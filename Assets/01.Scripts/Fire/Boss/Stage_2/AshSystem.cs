using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AshSystem : MonoBehaviour
{
    private int _remainCore = 0;

    private int _coreCount = 3;
    [SerializeField] private AshCore _corePrefab;
    private AshCore[] _cores = new AshCore[3];
    [SerializeField] private Transform[] _coreTrmArr = new Transform[3];

    [SerializeField] private UnityEvent _stageClearEvent;

    private void Start()
    {
        ResetSequence();
    }

    private void CreateCore()
    {
        for (int i = 0; i < _coreCount; i++)
        {
            _cores[i] = Instantiate(_corePrefab, _coreTrmArr[i].position, Quaternion.identity);
            _cores[i].SurpressedAction += HandleCoreDestroy;
        }
    }

    private void HandleCoreDestroy()
    {
        _remainCore--;
        if(_remainCore == 0 )
        {
            _stageClearEvent?.Invoke();
        }
    }

    public void ResetSequence()
    {
        _remainCore = _coreCount;
        CreateCore();
    }
}
