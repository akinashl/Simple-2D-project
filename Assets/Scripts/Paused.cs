using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    public float Timer;
    public float SecondTimer;
    PlayerMovement player;
    public BossScript boss;
    public GameObject PausePanel;
    public GameObject DeathScreen;
    public GameObject DeathScreenBG;
    public GameObject FinishingScreen;
    public GameObject FinishScreenBG;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        PausePanel.SetActive(false);

        DeathScreen.SetActive(false);

        DeathScreenBG.SetActive(false);

        FinishingScreen.SetActive(false);

        FinishScreenBG.SetActive(false);

        Timer = 3f;
        
        SecondTimer = 3f;
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

            if(player.health <= 0)
            {
                Health();
            }

            if(boss != null)
            {
                if(boss.health <= 0)
                {
                    FinishingTheGame();
                }
            }
        }
    }
    public void FinishingTheGame()
    {
        if(boss.health <= 0)
        {
            FinishingScreen.SetActive(true);
            FinishScreenBG.SetActive(true);
            SecondTimer -= Time.deltaTime;
            Debug.Log("Player Won");
        }

        if(SecondTimer <= 0f)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Health()
    {
        if(player.health <= 0)
        {
            DeathScreen.SetActive(true);
            DeathScreenBG.SetActive(true);
            Timer -= Time.deltaTime;
            Debug.Log("Death");
        }

        if(Timer <= 0f)
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
