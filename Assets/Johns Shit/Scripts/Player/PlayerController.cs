using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    TMP_Text ammoTB;

    public Camera cam;

    private bool forwards, backwards, left, right;

    #region Weapon Privates Variables
    private float _rifleAmmoCount;
    private float rifleAmmoCount
    {
        get
        {
            return _rifleAmmoCount;
        }
        set
        {
            _rifleAmmoCount = value;
            if (selectedWeapon == Weapon.rifle) ammoTB.text = _rifleAmmoCount.ToString() + "/" + rifleAmmoMax.ToString();
        }
    }
    private float rifleShootCooldown;
    private float rifleReloadTime;
    private bool reloadingRifle;
    private bool shooting;

    private float _sniperAmmoCount;
    private float sniperAmmoCount
    {
        get
        {
            return _sniperAmmoCount;
        }
        set
        {
            _sniperAmmoCount = value;
            if(selectedWeapon == Weapon.sniper) ammoTB.text = _sniperAmmoCount.ToString() + "/" + sniperAmmoMax.ToString();
        }
    }
    private float sniperShootCooldown;
    private float sniperReloadTime;
    private bool reloadingSniper;

    private float _swordAmmoCount;
    private float swordAmmoCount
    {
        get
        {
            return _swordAmmoCount;
        }
        set
        {
            _swordAmmoCount = value;
            if (selectedWeapon == Weapon.sword) ammoTB.text = _swordAmmoCount.ToString() + "/" + swordAmmoMax.ToString();
        }
    }
    private float swordShootCooldown;
    private float swordReloadTime;
    private bool reloadingSword;
    #endregion

    private enum Weapon {sword, rifle, sniper }
    private Weapon selectedWeapon;

    #region Weapon Public Variables
    public DamagePackage rifleDmgPkg;
    public float rifleAmmoMax { get; private set; }
    public float rifleRange { get; private set; }
    public float rifleROF { get; private set; }
    public float rifleReload { get; private set; }
    public float rifleSpread { get; private set; }
    public int riflePen { get; private set; }

    public DamagePackage sniperDmgPkg;
    public float sniperAmmoMax { get; private set; }
    public float sniperRange { get; private set; }
    public float sniperROF { get; private set; }
    public float sniperReload { get; private set; }
    public float sniperSpread { get; private set; }
    public int sniperPen { get; private set; }

    public DamagePackage swordDmgPkg;
    public float swordAmmoMax { get; private set; }
    public float swordROF { get; private set; }
    public float swordReload { get; private set; }
    #endregion

    public float moveSpeed { get; private set; }

    /// <summary>
    /// call sparingly
    /// </summary>
    /// <param name="newPlayerStats"></param>
    public void SetOnLoad(StatBlock newPlayerStats)
    {
        float[] rifleStats = newPlayerStats.ReturnValues("rifle", "final");
        float[] sniperStats = newPlayerStats.ReturnValues("sniper", "final");
        #region Setting Rifle Stats
        #region setting damage class
        rifleDmgPkg = new DamagePackage();
        rifleDmgPkg.damage = (int)rifleStats[0];
        switch (rifleStats[2])
        {
            case 0: // standard
                rifleDmgPkg.myType = DamagePackage.damageType.standard;
                break;
            case 1: // direct and splash
                rifleDmgPkg.myType = DamagePackage.damageType.direct;
                break;
            case 2: // AP
                rifleDmgPkg.myType = DamagePackage.damageType.AP;
                break;
            case 3: // true
                rifleDmgPkg.myType = DamagePackage.damageType.trueDamage;
                break;
        }
        switch (rifleStats[1])
        {
            case 0: // light
                rifleDmgPkg.myClass = DamagePackage.damageClass.light;
                break;
            case 1: // heavy
                rifleDmgPkg.myClass = DamagePackage.damageClass.heavy;
                break;
        }
        #endregion
        rifleAmmoMax = rifleStats[3];
        rifleAmmoCount = rifleAmmoMax;
        rifleReload = rifleStats[4];
        rifleROF = rifleStats[5];
        rifleRange = rifleStats[6];
        rifleSpread = rifleStats[7];
        riflePen = (int)rifleStats[8];
        #endregion
        #region Setting Sniper Stats
        #region setting damage class
        sniperDmgPkg = new DamagePackage();
        sniperDmgPkg.damage = (int)sniperStats[0];
        switch (sniperStats[2])
        {
            case 0: // standard
                sniperDmgPkg.myType = DamagePackage.damageType.standard;
                break;
            case 1: // direct and splash
                sniperDmgPkg.myType = DamagePackage.damageType.direct;
                break;
            case 2: // AP
                sniperDmgPkg.myType = DamagePackage.damageType.AP;
                break;
            case 3: // true
                sniperDmgPkg.myType = DamagePackage.damageType.trueDamage;
                break;
        }
        switch (sniperStats[1])
        {
            case 0: // light
                sniperDmgPkg.myClass = DamagePackage.damageClass.light;
                break;
            case 1: // heavy
                sniperDmgPkg.myClass = DamagePackage.damageClass.heavy;
                break;
        }
        #endregion
        sniperAmmoMax = sniperStats[3];
        sniperAmmoCount = sniperAmmoMax;
        sniperReload = sniperStats[4];
        sniperROF = sniperStats[5];
        sniperRange = sniperStats[6];
        sniperSpread = sniperStats[7];
        sniperPen = (int)sniperStats[8];
        #endregion
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 4;
        selectedWeapon = Weapon.rifle;
    }

    // Update is called once per frame
    void Update()
    {
        AimShoot();
        Move();
    }

    void FixedUpdate()
    {
    }
    
    void OnDrawGizmos()
    {
        Vector3 movDirection = GetDirection() * moveSpeed * Time.fixedDeltaTime;
        Vector3 movWorldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection;
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection + Vector3.up * 15f, new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection - Vector3.up * 15f);

    }


    void Move()
    {
        //get direction
        Vector3 movDirection = GetDirection() * moveSpeed * Time.fixedDeltaTime;
        Vector3 movWorldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection;
        //raycast from sky in that direction

        //print(movWorldPos - transform.position);

        RaycastHit movPos;
        //raycasts the floor in the direction that the player is moving from the sky. this should alayws return true
        if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection + Vector3.up *15f,Vector3.down,out movPos, 30f, 1 << 12))
        {
            //ray cast from to ankles
            //check if hit collider
            RaycastHit objCheck;
            Ray ankleRay = new Ray(transform.position - Vector3.up * 0.5f, movPos.point - transform.position);
            if (!Physics.SphereCast(transform.position - Vector3.up * 0.5f, 0.1f, (movPos.point + Vector3.up - transform.position), out objCheck, moveSpeed * Time.deltaTime * 12, 1 << 8))
            {
                Debug.DrawRay(transform.position - Vector3.up * 0.5f, (movPos.point + Vector3.up - transform.position) * 20f, Color.green);
                transform.position = movPos.point + Vector3.up;
            }
            else
            {
                Debug.DrawRay(transform.position - Vector3.up * 0.5f, (movPos.point + Vector3.up - transform.position) * 20f, Color.red);
                //      smoothiung based on normal bump
                //float moveAngle = Mathf.Rad2Deg * Mathf.Atan2(movDirection.z, movDirection.x);
                //float smoothAngle = Mathf.Rad2Deg * Mathf.Atan2(objCheck.normal.z, objCheck.normal.x) + 180;
                //if (smoothAngle > 360)
                //{
                //    smoothAngle -= 360;
                //}
                //if (smoothAngle < moveAngle - 35 || smoothAngle > moveAngle + 35)
                //{
                //    transform.position = transform.position + new Vector3(objCheck.normal.x, 0, objCheck.normal.z) * 0.01f;
                //}

                Vector3 adjustedNormal = Quaternion.Euler(0,90, 0) * objCheck.normal;
                transform.position = transform.position + Vector3.Project(movDirection,adjustedNormal) * Time.deltaTime * 50f;                
            }


        }
        //ray cast from to ankles
        //check if hit collider
        //move to that collider
    }

    //returns movement direction as vector 3
    Vector3 GetDirection()
    {
        Vector3 returnThis = Vector3.zero;

        //gets keys down and sets values true/false according
        if (Input.GetKeyDown(KeyCode.W))
        {
            forwards = true;
            backwards = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            backwards = true;
            forwards = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            left = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            right = false;
        }

        //sets values to false on key up
        if (Input.GetKeyUp(KeyCode.W))
        {
            forwards = false;
            if (Input.GetKey(KeyCode.S))
            {
                backwards = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            backwards = false;
            if (Input.GetKey(KeyCode.W))
            {
                forwards = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
            if (Input.GetKey(KeyCode.A))
            {
                left = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
            if (Input.GetKey(KeyCode.D))
            {
                right = true;
            }
        }

        if (forwards)
        {
            returnThis += transform.forward;
        }
        if (backwards)
        {
            returnThis -= transform.forward;
        }
        if (right)
        {
            returnThis += transform.right;
        }
        if (left)
        {
            returnThis -= transform.right;
        }
        returnThis = returnThis.normalized;
        return returnThis;
    }

    void AimShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            shooting = false;
        }
        switch (selectedWeapon)
        {
            case Weapon.rifle:
                #region Rifle Shooting
                //find point
                if (shooting && rifleAmmoCount > 0 && rifleShootCooldown < 0)
                {
                    RaycastHit camCast;
                    Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 40, 1 << 12);
                    // position off grid
                    Vector3 shootPoint = camCast.point + Vector3.up;
                    Debug.DrawLine(transform.position, shootPoint, Color.red, 0.1f);
                    GameObject shot = PlayerProjectilePool.playerPool.GetObject();

                    //line cast

                    shot.GetComponent<PlayerBulletLogic>().StartBullet(gameObject.transform.position, shootPoint, rifleRange, rifleDmgPkg);
                    shot.SetActive(true);
                    rifleAmmoCount--;
                    rifleShootCooldown = rifleROF;
                }
                else if (rifleAmmoCount <= 0 && !reloadingRifle)
                {
                    print(rifleReload);
                    rifleReloadTime = rifleReload;
                    reloadingRifle = true;
                    StartCoroutine(ReloadRifleCoro());
                }
                else
                {
                    rifleShootCooldown -= Time.deltaTime;
                }
                #endregion
                break;
            case Weapon.sniper:
                #region Sniper Shooting
                if (shooting && sniperAmmoCount > 0 && sniperShootCooldown < 0)
                {
                    RaycastHit camCast;
                    Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 40, 1 << 12);
                    // position off grid
                    Vector3 shootPoint = camCast.point + Vector3.up;
                    Debug.DrawLine(transform.position, shootPoint, Color.red, 0.1f);
                    GameObject shot = PlayerProjectilePool.playerPool.GetObject();

                    //line cast

                    shot.GetComponent<PlayerBulletLogic>().StartBullet(gameObject.transform.position, shootPoint, sniperRange, sniperDmgPkg);
                    shot.SetActive(true);
                    sniperAmmoCount--;
                    sniperShootCooldown = sniperROF;
                }
                else if (sniperAmmoCount <= 0 && !reloadingSniper)
                {
                    sniperReloadTime = sniperReload;
                    reloadingSniper = true;
                    StartCoroutine(ReloadSniperCoro());
                }
                else
                {
                    sniperShootCooldown -= Time.deltaTime;
                }
                #endregion
                break;
        }        
    }

    #region Reloads
    IEnumerator ReloadRifleCoro()
    {
        print("reloading");
        while(rifleReloadTime > 0)
        {
            if (selectedWeapon == Weapon.rifle)
            {
                rifleReloadTime -= Time.deltaTime;
            }
            yield return null;
        }
        rifleAmmoCount = rifleAmmoMax;
        reloadingRifle = false;
    }
    IEnumerator ReloadSniperCoro()
    {
        while (sniperReloadTime > 0)
        {
            if (selectedWeapon == Weapon.sniper)
            {
                sniperReloadTime -= Time.deltaTime;
            }
            yield return null;
        }
        sniperAmmoCount = sniperAmmoMax;
        reloadingSniper = false;
    }
    IEnumerator ReloadMeleeCoro()
    {
        while (swordReloadTime > 0)
        {
            if (selectedWeapon == Weapon.rifle)
            {
                swordReloadTime -= Time.deltaTime;
            }
            yield return null;
        }
        swordAmmoCount = swordAmmoMax;
        reloadingSword = false;
    }
    #endregion



}
