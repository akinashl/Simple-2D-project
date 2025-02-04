using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float health;
    private Transform player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        anim.SetBool("isRun", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BulletScript bullet = other.GetComponent<BulletScript>();
        if (other.CompareTag("Player"))
        {
            health -= 10;
        }
        else if (other.CompareTag("Bullet"))
        {
            health -= bullet.damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
