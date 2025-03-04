using UnityEngine;

public class DoorCode : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"));
        {
            Destroy(gameObject);
        }
    }
}
