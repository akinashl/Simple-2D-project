using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAttackPattrol : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool MoveinRight;
    Transform player; 
    bool chill = false;
    bool angry = false;
    bool goback = false;
    public float stoppingDistance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position)< positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position)< stoppingDistance)
        {
            angry = true;
            chill = false;
            goback = false;
        }
        if (Vector2.Distance(transform.position, player.position)> stoppingDistance)
        {
            goback = true;
            angry = false;
        }
        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goback == true)
        {
            GoBack();
        }
    }
    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            MoveinRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            MoveinRight = true;
        }
        if (MoveinRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 8f;
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

}
