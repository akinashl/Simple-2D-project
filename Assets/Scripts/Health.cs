using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helath : MonoBehaviour
{
    public RigidbodyMovement player;
    Image healthbar;
    public float maxHealth = 100f;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        player.HP = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = player.HP/maxHealth;
    }
}
