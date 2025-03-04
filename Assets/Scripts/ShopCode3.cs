using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCode1 : MonoBehaviour
{
    public CoinManager cm;
    public PlayerShoting ps;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(cm.coinCoint >= 50 && collision.gameObject.CompareTag("Player"))
        {
            ps.bulletDamage += 15;
            cm.coinCoint -= 50;
            Destroy(gameObject);
        }
    }
}
