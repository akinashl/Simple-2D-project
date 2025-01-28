using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScriptForOthers : MonoBehaviour
{
    public int health;
    public int maxhp;
    public int damage;
    
    public GameObject coin;
    public Transform coinPos;
    public Transform coinRot;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BulletScript bullet = other.GetComponent<BulletScript>();

        if(other.CompareTag("Bullet"))
        {
            health -= bullet.damage;
            Debug.Log("Enemy got hit");

            if (health <= 0)
            {
                Debug.Log("Enemy died");
                Destroy(gameObject);
                coin = Instantiate(coin, coinPos.position, coinRot.rotation);
            }
        }
    }
}
