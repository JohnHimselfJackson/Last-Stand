using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtilleryBuilding : BuildingDefence
{
    public Transform projSpawnPoint;
    public Animator myAnim;
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
        evasion = 0;
        healthMax = 600;
        healthCurrent = healthMax;
        attackRange = 20;
        myPos = transform.position;
        fireTime = 3;
        damage = new DamagePackage(DamagePackage.damageClass.heavy, DamagePackage.damageType.AP, 35, 0);
    }

    public override void Shoot()
    {
        base.Shoot();
        GameObject projectile = EnemyProjectilePool.enemyPool.GetObject();
        print(projectile);
        projectile.GetComponent<EnemyBulletLogic>().StartBullet(projSpawnPoint.position, activeTarget.transform.position, attackRange, damage);
    }

}
