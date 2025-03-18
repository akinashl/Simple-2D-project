using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    public float Timer;
    public float SecondTimer;
    bool playerDead = false;
    bool bossDead = false;
    PlayerMovement player;
    public BossScript boss;
    public GameObject PausePanel;
    public GameObject DeathScreen;
    public GameObject DeathScreenBG;
    public GameObject FinishingScreen;
    public GameObject FinishScreenBG;
    public Scene MenuScene;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        PausePanel.SetActive(false);

        DeathScreen.SetActive(false);

        DeathScreenBG.SetActive(false);

        FinishingScreen.SetActive(false);

        FinishScreenBG.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 
        if(!player.is_paused)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (player.is_paused)
                {
                    player.is_paused = false;
                    PausePanel.SetActive(false);
                    Time.timeScale = 1;
                }
                else
                {
                    PausePanel.SetActive(true);
                    Time.timeScale = 0;
                    player.is_paused = true;
                }
            }

            Health();

            FinishingTheGame();

            if(bossDead == true)
            {
                SecondTimer -= Time.deltaTime;
            }

            if (playerDead == true)
            {
                Timer -= Time.deltaTime;
            }
        }
    }
    public void FinishingTheGame()
    {
        if(boss.health <= 0 && !bossDead)
        {
            FinishingScreen.SetActive(true);
            FinishScreenBG.SetActive(true);
            SecondTimer = 3f;
            Debug.Log("Player Won");
            player.health = 10000;
            bossDead = true;
        }

        if(SecondTimer < 0f)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Health()
    {
        if(player.health <= 0 && !playerDead)
        {
            DeathScreen.SetActive(true);
            DeathScreenBG.SetActive(true);
            Timer = 3f;
            Debug.Log("Death");
            playerDead = true;
        }

        if(Timer < 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void PausePanelOff()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        player.is_paused = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
