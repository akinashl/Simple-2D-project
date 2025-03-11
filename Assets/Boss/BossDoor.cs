using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public GameObject boss;
    public Transform bosss;
    public Paused pause;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameObject bossObject = Instantiate(boss, bosss.position, bosss.rotation);
            pause.boss = bossObject.GetComponent<BossScript>();
        }
    }
}
