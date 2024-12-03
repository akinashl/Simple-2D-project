using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject respawnpoint;
    public GameObject Player;
    // Start is called before the first frame update
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.transform.position = respawnpoint.transform.position;
        }
    }
}
