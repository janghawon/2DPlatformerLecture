using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Camera _mainCam;
    public Camera MainCamera
    {
        get
        {
            if (_mainCam != null) return _mainCam;

            _mainCam = Camera.main;
            return _mainCam;
        }
    }

    private Transform _player;
    public Transform Player
    {
        get
        {
            if(_player != null)
                return _player;
            else
            {
                _player = FindObjectOfType<PlayerInput>().transform;
                return _player;
            }
        }
    }

    public int playerHP;

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
        return MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public Vector3 GetCanvasPos(Vector2 worldPos, RectTransform canvasRect)
    {
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(MainCamera, worldPos);
        Vector2 canvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, 
                                                                screenPoint, 
                                                                MainCamera, 
                                                                out canvasPos);
        return canvasPos;
    }
}
