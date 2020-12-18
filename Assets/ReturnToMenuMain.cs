using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuMain : MonoBehaviour
{
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
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        }
        if (count > 2)
        {
            LoadScene("MainMenu");
        }
    }


    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
