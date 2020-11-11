using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class ArtilleryBuilding : BuildingDefence
{
    public Transform projSpawnPoint;
    public Animator myAnim;
    public AudioClip fireSound;
    private void Awake()
    {
        myAnim = GetComponent<Animator>();
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

    public override void Shoot()
    {
        base.Shoot();
        myAnim.SetBool("shoot", true);
        Invoke("UnsetBool", 0.1f);
        GameObject projectile = EnemyProjectilePool.enemyPool.GetObject();
        EazySoundManager.PlaySound(fireSound, 0.3f);
        projectile.GetComponent<EnemyBulletLogic>().StartBullet(projSpawnPoint.position, activeTarget.transform.position, attackRange, damage);
    }
    
    void UnsetBool()
    {
        myAnim.SetBool("shoot", false);
    }
}
