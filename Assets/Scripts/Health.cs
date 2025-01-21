using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Helath : MonoBehaviour
{
    public PlayerMovement player;
    Image healthbar;
    public float maxHealth = 100f;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        player.HP = maxHealth;
    }
    void Update()
    {
        healthbar.fillAmount = player.HP/maxHealth;
    }
}
