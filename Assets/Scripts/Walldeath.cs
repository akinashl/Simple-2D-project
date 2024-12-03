using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walldeath : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Collision detected");
            Destroy(gameObject);
        }
    }

}
