using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public GameObject text;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            count += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            count = 0;
            text.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            text.SetActive(true);
        }
        if (count > 3)
        {
            LoadScene("MainMenu");
        }
    }


    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
