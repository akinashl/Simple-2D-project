using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyFollow : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public float enemyhp;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            enemyhp -= 5;
        }
        if (enemyhp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
