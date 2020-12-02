using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class AutogunBuildings : BuildingDefence
{
    public Transform projSpawnPoint;
    public Animator myAnim;
    public AudioClip fireSound;
    bool shooting;
    int shootCount;
    float timeCheck;

    public List<GameObject> fire;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();

        // Makes sure there is no fire when spawned in
        fire[0].SetActive(false);
        fire[1].SetActive(false);
        fire[2].SetActive(false);
        fire[3].SetActive(false);
        fire[4].SetActive(false);
    }
    private void Update()
    {
        GenericUpdate();
        UpdateShoot();

        // What happens at each damage state
        switch (damageState)
        {
            case DamageState.Healthy:
                fire[0].SetActive(false);
                fire[1].SetActive(false);
                fire[2].SetActive(false);
                fire[3].SetActive(false);
                fire[4].SetActive(false);
                break;
            case DamageState.Damaged:
                fire[0].SetActive(true);
                fire[1].SetActive(false);
                fire[2].SetActive(true);
                fire[3].SetActive(false);
                fire[4].SetActive(true);
                break;
            case DamageState.BadlyDamaged:
                fire[0].SetActive(true);
                fire[1].SetActive(true);
                fire[2].SetActive(true);
                fire[3].SetActive(true);
                fire[4].SetActive(true);
                break;
            case DamageState.Destroyed:
                fire[0].SetActive(false);
                fire[1].SetActive(false);
                fire[2].SetActive(false);
                fire[3].SetActive(false);
                fire[4].SetActive(false);
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myType = buildingType.defence;
        myClass = unitClass.light;
        armour = 1;
        evasion = 2;
        healthMax = 100;
        healthCurrent = healthMax;
        attackRange = 15;
        myPos = transform.position;
        fireTime = 1.5f;
        damage = new DamagePackage(DamagePackage.damageClass.light, DamagePackage.damageType.standard, 6, 0);
        shooting = false;
    }

    public override void Shoot()
    {
        base.Shoot();
        shooting = true;
        myAnim.SetBool("shoot", true);
        EazySoundManager.PlaySound(fireSound,0.2f,false, transform);
        shootCount = 0;

    }

    void UpdateShoot()
    {
        if (shooting && activeTarget)
        {
            if (timeCheck > 0.05)
            {
                GameObject projectile = EnemyProjectilePool.enemyPool.GetObject();
                if (projectile != null) projectile.GetComponent<EnemyBulletLogic>().StartBullet(projSpawnPoint.position, activeTarget.transform.position +new Vector3(Random.Range(-0.5f,0.5f),0, Random.Range(-0.5f, 0.5f)), attackRange, damage, 3);
                shootCount++;
                if(shootCount > 1) myAnim.SetBool("shoot", false);
                timeCheck = 0;
            }
            else
            {
                timeCheck += Time.deltaTime;
            }
        }
        if(shootCount > 4)
        {
            shooting = false;
            myAnim.SetBool("shoot", false);
        }
    }


}
