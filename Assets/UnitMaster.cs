using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaster : MonoBehaviour
{
    float health;
    int evasion;
    int armor;
    enum unitClass {heavy, light};
    unitClass myClass;
    float movespeed;
    float lineOfSight;
    float attackRange;
    DamagePackage damage;
    float attackCooldown;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActionLoop()
    {
        //move to cover if possible and under fire
        //shoot at enemy in range
        //move to flare
        //move to rally point
        //move to next target point

    }





}
