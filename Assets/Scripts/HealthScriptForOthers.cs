using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScriptForOthers : MonoBehaviour
{
    public int othershp;
    public int maxhp;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        othershp = maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        if (othershp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnColliderEnter2D(Collider2D collider)
    {
        FindObjectOfType<PlayerShoting>().bulletDamage = damage;

        if(collider.CompareTag("Bullet"))
        {
            othershp -= damage;
            Debug.Log("Enemy got hit");
        }
    }
}
