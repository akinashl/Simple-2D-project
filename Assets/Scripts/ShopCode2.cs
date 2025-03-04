using UnityEngine;

public class ShopCode2 : MonoBehaviour
{
    public CoinManager cm;
    public PlayerMovement pm;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(cm.coinCoint >= 50 && collision.gameObject.CompareTag("Player"))
        {
            pm._moveSpeed += 10f;
            pm._initialSpeed += 10f;
            cm.coinCoint -= 50;
            Destroy(gameObject);
        }
    }
}
