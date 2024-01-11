using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCam;

    private static GameManager _instance;
    public static GameManager Instanace
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<GameManager>();
            if (_instance == null)
            {
                Debug.LogError("Not Exist GameManager");
            }
            return _instance;
        }
    }

    public void ChangeScene(int sceneIdx)
    {
        SceneManager.LoadScene(sceneIdx);
    }

    public Vector3 GetMousePos()
    {
        if(_mainCam == null)
        {
            _mainCam = Camera.main;
        }
        return _mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
