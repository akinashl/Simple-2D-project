using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScriptForOthers : MonoBehaviour
{
    public float othershp;
    public float maxhp;
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
}
