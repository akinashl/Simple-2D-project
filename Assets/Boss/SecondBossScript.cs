using UnityEngine;

public class SecondBossScript : MonoBehaviour
{
    public bool dropbelow = false;
    public BossScript boss;
    public GameObject BOSS;
    public Transform bosslocation;
    // Update is called once per frame
    void Update()
    {
        if(boss.health <= 500 && dropbelow == false)
        {
            dropbelow = true;
            Instantiate(BOSS, bosslocation.position, bosslocation.rotation);
        }
    }
}