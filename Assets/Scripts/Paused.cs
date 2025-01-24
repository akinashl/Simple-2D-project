using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    PlayerMovement player;
    public GameObject PausePanel;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();

        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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
