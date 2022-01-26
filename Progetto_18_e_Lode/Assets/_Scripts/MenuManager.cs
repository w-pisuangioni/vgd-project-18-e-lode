using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    //static int lvlNum = 1;
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
        switch (PlayerPath.GetLvlAttuale())
        {
            case 1: SceneManager.LoadScene("Main"); break;
            case 2: SceneManager.LoadScene("Village"); break;
            case 3: SceneManager.LoadScene("Level3");break;
            case 4: SceneManager.LoadScene("Casa_abbandonata");break;
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainMenu2.0");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

   /* public static void IncLevelNumber()
    {
        lvlNum++;
    }*/

    public void NextLevel()
    {
        // SceneManager.LoadScene("Level" + lvlNum);
        switch (PlayerPath.GetLvlAttuale())
        {
            case 1: SceneManager.LoadScene("Village");break;
            case 2: SceneManager.LoadScene("Level3");break;
            case 3: SceneManager.LoadScene("Casa_abbandonata");break;
        }
    }

    public void Save()
    {
        SaveAndLoad.level = PlayerPath.GetLvlAttuale() + 1;
        SaveAndLoad.Save();
    }
    public void SaveEndGame()
    {
        SaveAndLoad.SaveScoreEnd();
    }
}
