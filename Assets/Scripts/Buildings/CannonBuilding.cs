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

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        GenericUpdate();
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
                projectile.GetComponent<EnemyBulletLogic>().StartBullet(projSpawnPointOne.position, projSpawnPointOne.position + turretBody.forward, attackRange, damage);
                secondPos = projSpawnPointTwo;
                break;
            case 1:
                projectile.GetComponent<EnemyBulletLogic>().StartBullet(projSpawnPointTwo.position, projSpawnPointTwo.position + turretBody.forward, attackRange, damage);
                secondPos = projSpawnPointOne;
                break;
        }
        Invoke("SecondShot", 0.1f);
        EazySoundManager.PlaySound(fireSound, 0.15f);


    }

    void SecondShot()
    {
        GameObject projectile = EnemyProjectilePool.enemyPool.GetObject();
        projectile.GetComponent<EnemyBulletLogic>().StartBullet(secondPos.position, secondPos.position + turretBody.forward, attackRange, damage);
        EazySoundManager.PlaySound(fireSound, 0.15f);
        myAnim.SetBool("shoot", false);
    }
}
