using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIDefine;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class UIScreenElement
{
    public UIScreenType myType;
    public UIObject[] uiObjectGroup;
}

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instanace
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<UIManager>();
            if (_instance == null)
            {
                Debug.LogError("Not Exist UIManager");
            }
            return _instance;
        }
    }

    private Canvas _canvas;
    public Canvas Canvas
    {
        get
        {
            if (_canvas != null)
                return _canvas;

            _canvas = FindObjectOfType<Canvas>();
            return _canvas;
        }
    }
    public Transform canvasTrm => Canvas.transform;

    [SerializeField] private List<UIScreenElement> _elementGroup = new List<UIScreenElement>();
    private Dictionary<UIScreenType, UIObject[]> _elementDic;

    [SerializeField] private UIScreenType _startUiScreen;
    private UIScreenType _currentUiType;

    private void Awake()
    {
        _elementDic  = new Dictionary<UIScreenType, UIObject[]>();
        foreach (UIScreenElement use in _elementGroup)
        {
            _elementDic.Add(use.myType, use.uiObjectGroup);
        }
        SceneManager.sceneLoaded += HandleUILoad;
        HandleUILoad(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    private void HandleUILoad(Scene scene, LoadSceneMode mode)
    {
        ChangeUIScreen((UIScreenType)scene.buildIndex);
    }

    public void ChangeUIScreen(UIScreenType uiType)
    {
        foreach (Transform t in canvasTrm)
        {
            Destroy(t.gameObject);
        }

        if(_elementDic.ContainsKey(uiType))
        {
            foreach (UIObject u in _elementDic[uiType])
            {
                GameObject uiObj = Instantiate(u.gameObject, canvasTrm);
                uiObj.name = uiObj.name.Replace("(Clone)", "");
            }
        }
        _currentUiType = uiType;
    }

}
