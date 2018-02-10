/*
 * Menu contoll script
 * by Vladislav Gorik
 * Last upd. 23.04.2017
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private GameObject menu;
    public GameObject Main;
    public GameObject Options;
    public float volume = 1f;
    public Dropdown quality;
    public Slider volumemaster;

    private void Start()
    {
        menu = gameObject;
        DontDestroyOnLoad(menu);
    }
   
	public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OptionsPanel()
    {
        Main.SetActive(false);
        Options.SetActive(true);
    }
    public void MainPanel()
    {
        Main.SetActive(true);
        Options.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void SetQuality()
    {
        switch (quality.value)
        {
            case 1:
                QualitySettings.SetQualityLevel(1);
                break;
            case 2:
                QualitySettings.SetQualityLevel(2);
                break;
            case 3:
                QualitySettings.SetQualityLevel(3);
                break;
            case 4:
                QualitySettings.SetQualityLevel(4);
                break;
            case 5:
                QualitySettings.SetQualityLevel(5);
                break;
           
        }
    }
    public void SoundMaster()
    {
        AudioListener.volume = volumemaster.value;
    }
   
}
