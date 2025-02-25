using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionShop : MonoBehaviour
{
    public CoinManager coinManager;
    public GameObject potion;
    public Transform spawnpoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && coinManager.coinCoint >= 5)
        {
            Destroy(gameObject);
            Instantiate(potion, spawnpoint.position, spawnpoint.rotation);
        }
    }
}
