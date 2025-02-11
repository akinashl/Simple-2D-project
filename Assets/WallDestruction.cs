using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestruction : MonoBehaviour
{
    public float hp = 10;
    void OnTriggerEnter2D(Collider2D other)
    {
        EndlessSpawnLevel2 level =  other.GetComponent<EndlessSpawnLevel2>();
        if(other.gameObject.CompareTag("Bullet"))
        {
            hp -= 5;
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
