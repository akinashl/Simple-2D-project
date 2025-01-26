using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript1 : MonoBehaviour
{
    public Transform lvl2;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = lvl2.position;
        }
    }
}
