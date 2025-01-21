using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
