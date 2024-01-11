using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void SetFlip(bool isLeft /*true is Look Left, */)
    {
        _spriteRenderer.flipX = isLeft;
    }
}
