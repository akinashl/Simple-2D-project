using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToLevel3 : MonoBehaviour
{
    public Transform lvl3;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = lvl3.position;
        }
    }
}
