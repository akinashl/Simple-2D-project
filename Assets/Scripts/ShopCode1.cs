using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCode3 : MonoBehaviour
{
    public CoinManager cm;
    public PlayerMovement pm;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(cm.coinCoint >= 20 && collision.gameObject.CompareTag("Player"))
        {
            pm.health += 100;
            cm.coinCoint -= 20;
            Destroy(gameObject);
        }
    }
}
