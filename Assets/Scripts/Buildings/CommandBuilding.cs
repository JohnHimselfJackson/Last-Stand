using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandBuilding : BuildingBasic
{
    public List<GameObject> fire;

    void Awake()
    {
        // Makes sure there is no fire when spawned in
        fire[0].SetActive(false);
        fire[1].SetActive(false);
        fire[2].SetActive(false);
        fire[3].SetActive(false);
        fire[4].SetActive(false);
        fire[5].SetActive(false);
        fire[6].SetActive(false);
        fire[7].SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        myType = buildingType.command;
        myClass = unitClass.heavy;
        armour = 4;
        evasion = 0;
        healthMax = 1000;
        healthCurrent = healthMax;

    }

    // Update is called once per frame
    void Update()
    {
        // What happens at each damage state
        switch (damageState)
        {
            case DamageState.Healthy:
                fire[0].SetActive(false);
                fire[1].SetActive(false);
                fire[2].SetActive(false);
                fire[3].SetActive(false);
                fire[4].SetActive(false);
                fire[5].SetActive(false);
                fire[6].SetActive(false);
                fire[7].SetActive(false);
                break;
            case DamageState.Damaged:
                fire[0].SetActive(true);
                fire[1].SetActive(false);
                fire[2].SetActive(true);
                fire[3].SetActive(false);
                fire[4].SetActive(true);
                fire[5].SetActive(true);
                fire[6].SetActive(false);
                fire[7].SetActive(false);
                break;
            case DamageState.BadlyDamaged:
                fire[0].SetActive(true);
                fire[1].SetActive(true);
                fire[2].SetActive(true);
                fire[3].SetActive(true);
                fire[4].SetActive(true);
                fire[5].SetActive(true);
                fire[6].SetActive(true);
                fire[7].SetActive(true);
                break;
            case DamageState.Destroyed:
                fire[0].SetActive(false);
                fire[1].SetActive(false);
                fire[2].SetActive(false);
                fire[3].SetActive(false);
                fire[4].SetActive(false);
                fire[5].SetActive(false);
                fire[6].SetActive(false);
                fire[7].SetActive(false);
                break;
        }
    }

    public override void BuildingDestroyed()
    {
        print("you won the game");
        Invoke("LoadMainMenu", 4);
        base.BuildingDestroyed();
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
