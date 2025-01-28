using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public int hp = 1;
    void Update()
    {
        if(hp <=0)
        {
            Destroy(gameObject);
        }
    }
}
