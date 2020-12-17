using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class ArtilleryBuilding : BuildingDefence
{
    public Transform projSpawnPoint;
    public Animator myAnim;
    public AudioClip fireSound;

    public List<GameObject> fire;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();

        // Makes sure there is no fire when spawned in
        fire[0].SetActive(false);
        fire[1].SetActive(false);
        fire[2].SetActive(false);
        fire[3].SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        myType = buildingType.defence;
        myClass = unitClass.heavy;
        armour = 3;
        evasion = 2;
        healthMax = 450;
        healthCurrent = healthMax;
        attackRange = 25;
        myPos = transform.position;
        fireTime = 3;
        damage = new DamagePackage(DamagePackage.damageClass.heavy, DamagePackage.damageType.AP, 35, 0);
    }

    private void Update()
    {
        GenericUpdate();
        // What happens at each damage state
        switch (damageState)
        {
            case DamageState.Healthy:
                fire[0].SetActive(false);
                fire[1].SetActive(false);
                fire[2].SetActive(false);
                fire[3].SetActive(false);
                break;
            case DamageState.Damaged:
                fire[0].SetActive(true);
                fire[1].SetActive(false);
                fire[2].SetActive(true);
                fire[3].SetActive(false);
                break;
            case DamageState.BadlyDamaged:
                fire[0].SetActive(true);
                fire[1].SetActive(true);
                fire[2].SetActive(true);
                fire[3].SetActive(true);
                break;
            case DamageState.Destroyed:
                fire[0].SetActive(false);
                fire[1].SetActive(false);
                fire[2].SetActive(false);
                fire[3].SetActive(false);
                break;
        }
    }

    public override void Shoot()
    {
        base.Shoot();
        myAnim.SetBool("shoot", true);
        Invoke("UnsetBool", 0.1f);
        GameObject projectile = EnemyProjectilePool.enemyPool.GetObject();
        EazySoundManager.PlaySound(fireSound, 0.15f, false, transform);
        projectile.GetComponent<EnemyBulletLogic>().StartBullet(projSpawnPoint.position, activeTarget.transform.position, attackRange, damage, 6);
    }
    
    void UnsetBool()
    {
        myAnim.SetBool("shoot", false);
    }
}
