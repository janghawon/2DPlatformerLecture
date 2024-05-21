using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerDie>(out PlayerDie pd))
        {
            pd.CreateResetProcess();
            PlayerState.isDie = true;
        }
    }
}
