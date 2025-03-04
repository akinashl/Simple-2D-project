using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float timer;
    public float health = 1000;
    public PlayerMovement pm;
    public BulletScript bs;
    public GameObject golem;
    public GameObject slime;
    public Transform spawnpos1;
    public Transform spawnpos2;
    public Transform spawnpos3;
    // Start is called before the first frame update
    void Start()
    {
        timer = 10f;
        Instantiate(golem, spawnpos1.position, spawnpos1.rotation);
        Instantiate(golem, spawnpos2.position, spawnpos2.rotation);
        Instantiate(golem, spawnpos3.position, spawnpos3.rotation);
        Instantiate(slime, spawnpos1.position, spawnpos1.rotation);
        Instantiate(slime, spawnpos2.position, spawnpos2.rotation);
        Instantiate(slime, spawnpos3.position, spawnpos3.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer <= 0)
        {
        Instantiate(golem, spawnpos1.position, spawnpos1.rotation);
        Instantiate(golem, spawnpos2.position, spawnpos2.rotation);
        Instantiate(golem, spawnpos3.position, spawnpos3.rotation);
        Instantiate(slime, spawnpos1.position, spawnpos1.rotation);
        Instantiate(slime, spawnpos2.position, spawnpos2.rotation);
        Instantiate(slime, spawnpos3.position, spawnpos3.rotation);
        timer = 10f;
        }
        timer -= Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            pm.health -= 40;
            health -= 40;
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health -= bs.damage;
        }
    }
}
