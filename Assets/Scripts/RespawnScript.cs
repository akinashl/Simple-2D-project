using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject spawn_point;
    public GameObject Player;
    // Start is called before the first frame update
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.transform.position = spawn_point.transform.position;
        }
    }
}
