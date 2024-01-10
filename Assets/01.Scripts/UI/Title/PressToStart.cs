using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PressToStart : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pressText;
    [SerializeField][Range(0.1f, 1f)] private float _fadeTime;

    private void Start()
    {
        _pressText.DOFade(0, _fadeTime).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            GameManager.Instanace.ChangeScene(SceneType.InGameScene);
        }
    }
}
