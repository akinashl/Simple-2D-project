using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestructors : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.CompareTag("Player"))
    {
        Debug.Log("Collision detected");
        Destroy(gameObject);
    }
  }
}
