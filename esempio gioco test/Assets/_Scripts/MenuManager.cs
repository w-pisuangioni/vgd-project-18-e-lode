using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    static int lvlNum = 1;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TryAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public static void IncLevelNumber()
    {
        lvlNum++;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + lvlNum);
    }

    public void Save()
    {
        //implementare
    }
}
