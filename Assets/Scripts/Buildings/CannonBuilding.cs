using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class CannonBuilding : BuildingDefence
{
    public Transform projSpawnPointOne;
    public Transform projSpawnPointTwo;
    Transform secondPos;
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
    // Start is called before the first frame update
    void Start()
    {
        myType = buildingType.defence;
        myClass = unitClass.heavy;
        armour = 2;
        evasion = 0;
        healthMax = 250;
        healthCurrent = healthMax;
        attackRange = 20;
        myPos = transform.position;
        fireTime = 1.5f;
        damage = new DamagePackage(DamagePackage.damageClass.heavy, DamagePackage.damageType.standard, 18, 0);
    }

    public override void Shoot()
    {
        GameObject projectile = EnemyProjectilePool.enemyPool.GetObject();
        myAnim.SetBool("shoot", true);
        base.Shoot();
        switch(Random.Range((int)0, (int)2))
        {
            case 0:
                projectile.GetComponent<EnemyBulletLogic>().StartBullet(projSpawnPointOne.position, projSpawnPointOne.position + turretBody.forward, attackRange, damage, 4);
                secondPos = projSpawnPointTwo;
                break;
            case 1:
                projectile.GetComponent<EnemyBulletLogic>().StartBullet(projSpawnPointTwo.position, projSpawnPointTwo.position + turretBody.forward, attackRange, damage, 4);
                secondPos = projSpawnPointOne;
                break;
        }
        Invoke("SecondShot", 0.1f);
        EazySoundManager.PlaySound(fireSound, 1000f,false,transform);


    }

    void SecondShot()
    {
        GameObject projectile = EnemyProjectilePool.enemyPool.GetObject();
        projectile.GetComponent<EnemyBulletLogic>().StartBullet(secondPos.position, secondPos.position + turretBody.forward, attackRange, damage, 4);
        EazySoundManager.PlaySound(fireSound, 1000f, false, transform);
        myAnim.SetBool("shoot", false);
    }
}
