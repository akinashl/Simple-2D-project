using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public GameObject boss;
    public Transform bosss;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(boss, bosss.position, bosss.rotation);
        }
    }
}
