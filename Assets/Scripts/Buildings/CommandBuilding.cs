using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandBuilding : BuildingBasic
{
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
        
    }

    public override void BuildingDestroyed()
    {
        print("you won the game");
        SceneManager.LoadScene(0);
        base.BuildingDestroyed();
    }
}
