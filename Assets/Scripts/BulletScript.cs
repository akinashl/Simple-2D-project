using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int damage;
    public int enemyhp;

    void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<PlayerShoting>().bulletDamage = damage;
        FindObjectOfType<HealthScriptForOthers>().othershp = enemyhp;
        if (collision.gameObject)
        {
            Destroy(gameObject);
        }


        /*if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyhp -= damage;
            Debug.Log("HP TAKEN");
        }*/
    }
}
