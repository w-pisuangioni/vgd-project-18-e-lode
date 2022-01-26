using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject panel;
    public GameObject image;
    public GameObject exit;
    public GameObject menu;
    public GameObject hud;
    private bool isPaused;
    public GameObject countdown;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        panel.SetActive(false);
        image.SetActive(false);
        exit.SetActive(false);
        menu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused && countdown.activeSelf == false)
                Pause();
            else
                if(isPaused)
                    Unpause();
        }
    }

    void Pause()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
        AudioListener.pause = true;
        panel.SetActive(true);
        image.SetActive(true);
        exit.SetActive(true);
        menu.SetActive(true);
        hud.SetActive(false);
        isPaused = true;

    }

    void Unpause()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        panel.SetActive(false);
        image.SetActive(false);
        isPaused = false;
        exit.SetActive(false);
        menu.SetActive(false);
        hud.SetActive(true);
    }
}
