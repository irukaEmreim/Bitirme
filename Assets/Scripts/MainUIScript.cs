using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainUIScript : MonoBehaviour
{
    public Slider audioSlider;    
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Start() {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = audioSlider.value; 
        Save();
    }

    public void Load()
    {
        audioSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",audioSlider.value);
    }
    public GameObject oyun;

    public void CloseUI()
    {
        oyun.SetActive(false);
        Time.timeScale = 1f;

    }

}
