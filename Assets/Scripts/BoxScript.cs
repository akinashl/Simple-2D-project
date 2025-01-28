using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BoxScript : MonoBehaviour
{
    public GameObject potion;
    public Transform potionspawn;
    public Transform potionrotation;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 30;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            health -= 10;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(potion, potionrotation.position, potionrotation.rotation);
        }
    }
}
