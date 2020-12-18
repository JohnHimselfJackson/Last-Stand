using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject optionsUI;


    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    public void OptionsLoad(bool loadType)
    {
        if (loadType)
        {
            menuUI.SetActive(false);
            optionsUI.SetActive(true);
        }
        else
        {
            menuUI.SetActive(true);
            optionsUI.SetActive(false);
        }
    }

}
