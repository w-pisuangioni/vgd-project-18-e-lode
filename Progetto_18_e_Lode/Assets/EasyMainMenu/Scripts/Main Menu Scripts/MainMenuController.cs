using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public class MainMenuController : MonoBehaviour
{

    Animator anim;

    public string newGameSceneName;
    public int quickSaveSlotID;

    [Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public GameObject StartGameOptionsPanel;
    public GameObject GamePanel;
    public GameObject ControlsPanel;
    public GameObject GfxPanel;
    public GameObject GameInfo;
    public GameObject SoundOptions;
    public GameObject Load;
    public GameObject Scores;

    public AudioMixer audioMixer;
    public float volumeIniziale;
    public Slider slider;
    public Toggle fullScreenButton;
    public Text fullScreenButtonText;
    Resolution[] resolutions;
    public Dropdown resolutionsDropdown;
    public Dropdown qualityDropdown;


    // Use this for initialization
    void Start()
    {
        audioMixer.GetFloat("volume", out volumeIniziale);
        //Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen);//imposta la risoluzione a quella inizale del configuratore
        slider.value = volumeIniziale;
        SetFullScreen(Screen.fullScreen);//imposta il testo della risoluzione inizale

        //Gestione Risoluzione
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)//aggiunge le impostazioni alla lista di stringhe "options"
        {
            options.Add(resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz");
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();

        //Gesione qualità
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();

        //Gestione mouse

        //roba di base
        anim = GetComponent<Animator>();
        //new key
        PlayerPrefs.SetInt("quickSaveSlot", quickSaveSlotID);
        SaveAndLoad.Load(); //carica dati da file save.bin
    }

    void Update()
    {
        if (!File.Exists("save.bin"))
            Load.SetActive(false);
        else
            Load.SetActive(true);

        if (File.Exists("nSaves.bin"))
            SaveAndLoad.Load_nSaves();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        if (isFullscreen)
            fullScreenButtonText.text = "on";
        else
            fullScreenButtonText.text = "off";
    }
    public void SetAxisX(float speedX)
    {


    }

    #region Open Different panels

    public void openOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(true);
        StartGameOptionsPanel.SetActive(false);
        GameInfo.SetActive(false);
        Scores.SetActive(false);


        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }
    public void openStartGameOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(true);
        GameInfo.SetActive(false);
        Scores.SetActive(false);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }
    public void openInfo()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(false);
        Scores.SetActive(false);
        GameInfo.SetActive(true);


        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }
    public void openScores()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(false);
        GameInfo.SetActive(false);
        Scores.SetActive(true);


        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }
    public void openOptions_Game()
    {
        //enable respective panel
        GamePanel.SetActive(true);
        SoundOptions.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        GameInfo.SetActive(false);
        Scores.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void openOptions_Controls()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        SoundOptions.SetActive(false);
        ControlsPanel.SetActive(true);
        GfxPanel.SetActive(false);
        GameInfo.SetActive(false);
        Scores.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void openOptions_Gfx()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        SoundOptions.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(true);
        GameInfo.SetActive(false);
        Scores.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void openSoundOptions()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        SoundOptions.SetActive(true);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        GameInfo.SetActive(false);
        Scores.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void newGame()
    {
        if (!string.IsNullOrEmpty(newGameSceneName))
        {
            Score.SetTotScore(0);
            SceneManager.LoadScene(newGameSceneName);
        }
        else
            Debug.Log("Please write a scene name in the 'newGameSceneName' field of the Main Menu Script and don't forget to " +
                "add that scene in the Build Settings!");
    }

    public void loadGame()
    {
        switch (SaveAndLoad.level)
        {
            case 1: SceneManager.LoadScene("Main"); break;
            case 2: SceneManager.LoadScene("Village"); break;
            case 3: SceneManager.LoadScene("Level3"); break;
        }
    }
    public void DeleteScores()
    {
        SaveAndLoad.DeleteScores();
    }
    #endregion

    #region Back Buttons

    public void back_options()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("buttonTweenAnims_off");

        //disable BLUR
        // Camera.main.GetComponent<Animator>().Play("BlurOff");

        //play click sfx
        playClickSound();
    }

    public void back_options_panels()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("OptTweenAnim_off");

        //play click sfx
        playClickSound();

    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Sounds
    public void playHoverClip()
    {

    }

    void playClickSound()
    {

    }


    #endregion
}
