using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] private GameObject _gameResetProcess;

    public void CreateResetProcess()
    {
        Instantiate(_gameResetProcess, UIManager.Instanace.canvasTrm);
    }
}
