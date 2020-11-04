using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer mixer;
    [SerializeField]
    private GameObject optionMenu, mainMenu;

    public void SetMain(float sliderValue)
    {
        SetVol(sliderValue, "MainVol");
    }

    public void SetMusic(float sliderValue)
    {
        SetVol(sliderValue, "MusicVol");
    }

    public void SetEffects(float sliderValue)
    {
        SetVol(sliderValue, "EffectsVol");
    }

    void SetVol(float sliderValue, string childMix)
    {
        mixer.SetFloat(childMix, Mathf.Log10(sliderValue) * 20);
    }

    public void OpenOptions()
    {
        //make sure to load previous sound levels from player prefs
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PregameStats");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("creditsScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
