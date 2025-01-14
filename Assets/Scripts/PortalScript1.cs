using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript1 : MonoBehaviour
{
    void OnColiderEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector2(34f, 175f);
        }
    }
}
