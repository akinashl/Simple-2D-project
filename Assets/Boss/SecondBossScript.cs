using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class SecondBossScript : MonoBehaviour
{
    public bool dropbelow = false;
    public BossScript boss;
    public GameObject BOSS;
    public Transform bosslocation;
    // Update is called once per frame
    void Update()
    {
        if(boss.health <= 50 && dropbelow == false)
        {
            Instantiate(BOSS, bosslocation.position, bosslocation.rotation);
            dropbelow = true;
        }
    }
}
