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
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 30;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP -= 10;
        }
        if (HP <= 0)
        {
            Destroy(gameObject);
            Instantiate(potion, potionrotation.position, potionrotation.rotation);
        }
    }
}
