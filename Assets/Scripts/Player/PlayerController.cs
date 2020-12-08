﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Hellmade.Sound;

public class PlayerController : MonoBehaviour
{
    public Transform projectielStart;
    public Camera cam;
    public GameObject myCanvas;
    public Animator myAnim;
    public GameObject animGO;
    public Image equippedImage, swappedImage;
    public Sprite arSprite;
    public Sprite sniperSprite;

    #region Layer Masks
    int groundLayerMask = 1 << 12;
    int nonTraversableLayerMask = (1 << 8) | (1 << 10) | (1 << 11) | (1 << 12) | (1 << 13);
    #endregion

    public bool playerLocked;
    public bool groundBool;

    #region Movement Variables
    public bool diving;
    public enum diveState { not, started, end }
    public diveState currentDiveState = diveState.not;
    Vector3 diveStartPos;
    Vector3 divePos;
    Vector3 diveDirection;
    float diveStandDelay;
    float standtime = 0.0f;
    private bool forwards, backwards, left, right, sprinting;
    private float sprintSpeedChange = 3f;
    public float moveSpeed { get; private set; }
    #endregion

    #region All Weapon Variables
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
            if (selectedWeapon == Weapon.rifle) ammoTB.text = "Rifle:  " + _rifleAmmoCount.ToString() + "/" + rifleAmmoMax.ToString();
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
            if (selectedWeapon == Weapon.sniper) ammoTB.text = "Sniper:  " + _sniperAmmoCount.ToString() + "/" + sniperAmmoMax.ToString();
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

    private enum Weapon { sword, rifle, sniper }
    private Weapon selectedWeapon;

    List<Weapon> availableWeapons = new List<Weapon>();
    float swapTimer;
    float swapDelay = 1;
    [SerializeField]
    TMP_Text ammoTB;
    [SerializeField]
    WeaponUIController weaponUIController;

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
    #endregion

    #region Ability Variables
    GrenadeLauncher gL;
    public bool gotGL;

    SniperLaser sL;
    public bool gotSL;
    public bool sniperLaserActive;
    #endregion

    #region Audio
    private AudioClip gunShot;
    [SerializeField]
    AudioClip reloadAudio;
    #endregion

    /// <summary>
    /// call sparingly
    /// </summary>
    /// <param name="newPlayerStats"></param>
    public void SetOnLoad(StatBlock newPlayerStats)
    {
        myCanvas.SetActive(true);
        moveSpeed = newPlayerStats.ReturnValues("base", "final")[1];
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
        rifleDmgPkg.UFD = rifleReload * 1.3f;
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
        sniperDmgPkg.UFD = sniperReload * 1.3f;
        #endregion
        sniperAmmoMax = sniperStats[3];
        sniperAmmoCount = sniperAmmoMax;
        sniperReload = sniperStats[4];
        sniperROF = sniperStats[5];
        sniperRange = sniperStats[6];
        sniperSpread = sniperStats[7];
        sniperPen = (int)sniperStats[8];
        #endregion
        switch (selectedWeapon)
        {
            case Weapon.rifle:
                myAnim.SetFloat("shootMultiplier", 0.567f / rifleROF);
                break;
            case Weapon.sniper:
                myAnim.SetFloat("shootMultiplier", 0.567f / sniperROF);
                break;
        }
    }

    private void Awake()
    {
        EazySoundManager.GlobalVolume = 1000;
        EazySoundManager.GlobalSoundsVolume = 100;
    }
    // Start is called before the first frame update
    void Start()
    {
        gunShot = PlayerPrefabReferences.PPR.shotAudio;

        gL = GetComponent<GrenadeLauncher>();
        sL = GetComponent<SniperLaser>();
        sniperLaserActive = false;

        availableWeapons.Add(Weapon.sniper);
        availableWeapons.Add(Weapon.rifle);

        moveSpeed = 4;
        selectedWeapon = Weapon.rifle;
        gunShot = PlayerPrefabReferences.PPR.shotAudio;
    }

    // Update is called once per frame
    void Update()
    {
        if (groundBool)
        {
            GroundPlayer();
        }
        InputMaster();
    }

    void InputMaster()
    {
        if (!playerLocked)
        {
            SprintCheck();
            if (currentDiveState == diveState.not)
            {
                AimGun();
                ForceReload();
                ActiveAbilityInput();
                WeaponSecondaries();
                SwitchWeapon();
                AimShoot();
                if (!diving)
                {
                    Move();
                }
                LoadStatScreen();
                Dive();
                
            }
            else
            {
                Dive();
                GetDirection();
            }
        }
    }
    
    void OnDrawGizmos()
    {
        //Vector3 movDirection = GetDirection() * moveSpeed * Time.fixedDeltaTime;
        //Vector3 movWorldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection;
        //Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection + Vector3.up * 15f, new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection - Vector3.up * 15f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(divePos, 2f);
    }

    #region Player Movement
    void Move()
    {
        float moveSpeedTemp = moveSpeed;
        if (sprinting)
        {
            moveSpeedTemp *= sprintSpeedChange;

        }
        //get direction
        Vector3 movDirection = GetDirection() * moveSpeedTemp * Time.deltaTime;
        Vector3 movWorldPos = new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection;
        if (sprinting)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.Atan2(-movDirection.z, movDirection.x) * Mathf.Rad2Deg + 90, transform.rotation.eulerAngles.z);
        }
        //raycast from sky in that direction

        //print(movWorldPos - transform.position);

        RaycastHit movPos;
        //raycasts the floor in the direction that the player is moving from the sky. this should alayws return true
        if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z) + movDirection + Vector3.up *15f,Vector3.down,out movPos, 30f, groundLayerMask))
        {
            //ray cast from to ankles
            //check if hit collider
            RaycastHit objCheck;
            Ray ankleRay = new Ray(transform.position - Vector3.up * 0.5f, movPos.point - transform.position);
            if (!Physics.SphereCast(transform.position - Vector3.up * 0.5f, 0.1f, (movPos.point + Vector3.up - transform.position), out objCheck, moveSpeedTemp * Time.deltaTime * 12, nonTraversableLayerMask))
            {
                transform.position = movPos.point + Vector3.up;
            }
            else
            {
                Vector3 adjustedNormal = Quaternion.Euler(0,90, 0) * objCheck.normal;
                Vector3 normalBasedMovePos = transform.position + Vector3.Project(movDirection,adjustedNormal) * Time.deltaTime * 50f;
                RaycastHit testPos;
                if(!Physics.SphereCast(transform.position - Vector3.up * 0.5f, 0.1f, (adjustedNormal), out testPos, moveSpeedTemp * Time.deltaTime * 12, nonTraversableLayerMask))
                {
                    transform.position = normalBasedMovePos;
                }
                GroundPlayer();
            }

        }
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
            returnThis += Vector3.forward;
        }
        if (backwards)
        {
            returnThis -= Vector3.forward;
        }
        if (right)
        {
            returnThis += Vector3.right;
        }
        if (left)
        {
            returnThis -= Vector3.right;
        }
        returnThis = returnThis.normalized;
        /*
        if(returnThis != Vector3.zero && !diving && !shooting)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.Atan2(-returnThis.z, returnThis.x) * Mathf.Rad2Deg + 90, transform.rotation.eulerAngles.z);
        }
        */
        //finds angles to convert player directions for animation
        float moveAngleRad = Mathf.Atan2(returnThis.z, returnThis.x);
        float playerAngleRad = Mathf.Atan2(transform.forward.z, transform.forward.x);
        float worldForwardRad = Mathf.Atan2(0,1);
        float angleDifference = moveAngleRad - playerAngleRad;

        //sets animation for legs
        if(returnThis == Vector3.zero)
        {
            myAnim.SetFloat("xVel", 0);
            myAnim.SetFloat("yVel", 0);
        }
        else
        {
            myAnim.SetFloat("xVel", Mathf.Cos(worldForwardRad + angleDifference + 90));
            myAnim.SetFloat("yVel", Mathf.Sin(worldForwardRad + angleDifference + 90));
        }
        //returnThis = Vector3.zero;
        return returnThis;
    }
    void GroundPlayer()
    {
        RaycastHit ground;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.down, out ground, 30f, 1 << 12))
        {
            transform.position = ground.point + Vector3.up;
        }
    }
    void Dive()
    {
        switch (currentDiveState)
        {
            case diveState.not:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentDiveState = diveState.started;
                    myAnim.SetBool("diving", true);
                    diving = true;
                }
                if(currentDiveState == diveState.started)
                {
                    float moveSpeedTemp = moveSpeed;
                    diveDirection = GetDirection();
                    RaycastHit divePosHit;
                    //sky to ground raycast to get desired move location
                    if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z) + (diveDirection * 3 * 3.6f) + Vector3.up * 15f, Vector3.down, out divePosHit, 30f, groundLayerMask))
                    {
                        //ray cast from to ankles
                        //check if hit collider
                        RaycastHit objCheck;
                        Ray ankleRay = new Ray(transform.position - Vector3.up * 0.5f, divePosHit.point - transform.position);
                        Debug.DrawLine(transform.position - Vector3.up * 0.5f, divePosHit.point + Vector3.up * 0.5f, Color.green, 1f);
                        //checkcs if path is free
                        if (!Physics.SphereCast(transform.position - Vector3.up * 0.5f, 0.1f, (divePosHit.point + Vector3.up - transform.position), out objCheck, 3 * 1, nonTraversableLayerMask))
                        {
                            //since path was free sets the start location to the dive pos
                            divePos = divePosHit.point + Vector3.up;
                        }
                        //path was not free
                        else
                        {
                            if ((objCheck.point- transform.position - Vector3.up * 0.5f).magnitude > 1.3f)
                            {
                                Debug.DrawLine(transform.position - Vector3.up * 0.5f, objCheck.point, Color.red, 1f);
                                //sets the dive to pos to a point half a unit back from the point where the raycast hit the obstacle
                                divePos = transform.position + diveDirection * ((objCheck.point - transform.position - Vector3.up * 0.5f).magnitude - 1f);
                                print(diveDirection);
                            }
                            else
                            {
                                currentDiveState = diveState.end;
                            }
                        }
                    }
                    diveStartPos = transform.position; 
                    GroundPlayer();
                }
                
                break;
            case diveState.started:
                Vector3 movDirection = diveDirection;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.Atan2(-movDirection.z, movDirection.x) * Mathf.Rad2Deg + 90, transform.rotation.eulerAngles.z);
                myAnim.SetBool("diving", false);
                if ((divePos-transform.position).magnitude < 1f || diveDirection == Vector3.zero)
                {
                    GroundPlayer();
                    currentDiveState = diveState.end;
                    diveStandDelay = standtime; 
                }
                else
                {
                    transform.position = transform.position + diveDirection * 6 * Time.deltaTime;
                    GroundPlayer();
                }

                break;
            case diveState.end:
                if(diveStandDelay <= 0)
                {
                    GroundPlayer();
                    currentDiveState = diveState.not;
                    diving = false;
                    if (Input.GetMouseButton(0))
                    {
                        shooting = true;
                        sprinting = false;
                    }
                }
                else
                {
                    GroundPlayer();
                    diveStandDelay -= Time.deltaTime;
                }
                break;
        }
    }
    void SprintCheck()
    {
        if((Input.GetKeyDown(KeyCode.LeftShift)) && !shooting)
        {
            sprinting = true;
            myAnim.SetBool("sprinting", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
            myAnim.SetBool("sprinting", false);
        }
    }
    #endregion

    #region Weapons
    void AimShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooting = true;
            myAnim.SetBool("shooting", true);
            sprinting = false;
            myAnim.SetBool("sprinting", false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            shooting = false;
            myAnim.SetBool("shooting", false);
            if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift)) && !shooting)
            {
                sprinting = true;
                myAnim.SetBool("sprinting", true);
            }
        }
        switch (selectedWeapon)
        {
            case Weapon.rifle:
                #region Rifle Shooting
                //find point
                if (shooting && rifleAmmoCount > 0 && rifleShootCooldown < 0)
                {
                    RaycastHit camCast;
                    Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 100, 1 << 12);
                    // position off grid
                    Vector3 shootPoint = camCast.point + Vector3.up*2;
                    Debug.DrawLine(transform.position, shootPoint, Color.red, 0.1f);
                    GameObject shot = PlayerProjectilePool.playerPool.GetObject();

                    //line cast

                    shot.GetComponent<PlayerBulletLogic>().StartBullet(projectielStart.position, shootPoint, rifleRange, rifleDmgPkg);
                    EazySoundManager.PlaySound(gunShot, 0.01f, false, projectielStart);
                    shot.SetActive(true);
                    rifleAmmoCount--;
                    rifleShootCooldown = rifleROF;
                }
                else if (rifleAmmoCount <= 0 && !reloadingRifle)
                {
                    print(rifleReload);
                    rifleReloadTime = rifleReload;
                    reloadingRifle = true;
                    myAnim.SetFloat("reloadMultiplier", 3.3f / rifleReload);
                    myAnim.SetBool("reloading", true);
                    EazySoundManager.PlaySound(reloadAudio, 0.01f);
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
                if (shooting && sniperAmmoCount > 0 && sniperShootCooldown < 0 && !sniperLaserActive)
                {
                    RaycastHit camCast;
                    Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 40, 1 << 12);
                    // position off grid
                    Vector3 shootPoint = camCast.point + Vector3.up;
                    Debug.DrawLine(transform.position, shootPoint, Color.red, 0.1f);
                    GameObject shot = PlayerProjectilePool.playerPool.GetObject();

                    //line cast

                    shot.GetComponent<PlayerBulletLogic>().StartBullet(projectielStart.position, shootPoint, sniperRange, sniperDmgPkg);
                    EazySoundManager.PlaySound(gunShot, 0.05f, false, projectielStart);
                    shot.SetActive(true);
                    sniperAmmoCount--;
                    sniperShootCooldown = sniperROF;
                }
                else if (sniperAmmoCount <= 0 && !reloadingSniper)
                {
                    sniperReloadTime = sniperReload;
                    reloadingSniper = true;
                    myAnim.SetFloat("reloadMultiplier", 3.3f / sniperReload);
                    myAnim.SetBool("reloading", true);
                    EazySoundManager.PlaySound(reloadAudio, 0.01f);
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
    void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && swapTimer <= 0)
        {
            for (int ww = 0; ww < availableWeapons.Count; ww++)
            {
                if(availableWeapons[ww] != selectedWeapon)
                {
                    selectedWeapon = availableWeapons[ww];
                    switch (selectedWeapon)
                    {
                        case Weapon.sniper:
                            equippedImage.sprite = sniperSprite;
                            swappedImage.sprite = arSprite;
                            sniperAmmoCount = sniperAmmoCount;
                            myAnim.SetFloat("shootMultiplier", 0.567f/sniperROF);
                            print("now selected sniper");
                            break;
                        case Weapon.rifle:
                            equippedImage.sprite = arSprite;
                            swappedImage.sprite = sniperSprite;
                            weaponUIController.SwapWeapon("Rifle", (int)rifleAmmoMax, (int)rifleAmmoCount, rifleReloadTime, 1 / rifleROF);
                            rifleAmmoCount = rifleAmmoCount;
                            myAnim.SetFloat("shootMultiplier", 0.567f / rifleROF);
                            sL.EndLaser();
                            print("now selected rifle");
                            break;
                        case Weapon.sword:
                            print("now selected sword");
                            break;
                    }
                    break;
                }
            }
            swapTimer = swapDelay;
            print(selectedWeapon);
        }
        if(swapTimer > 0)
        {
            swapTimer -= Time.deltaTime;
        }
    }
    #region Reloads
    void ForceReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EazySoundManager.PlaySound(reloadAudio, 0.01f);
            switch (selectedWeapon)
            {
                case Weapon.rifle:
                    rifleAmmoCount = 0;
                    rifleReloadTime = rifleReload;
                    print(rifleReload);
                    myAnim.SetFloat("reloadMultiplier", 3.3f/ rifleReload);
                    myAnim.SetBool("reloading", true);
                    reloadingRifle = true;
                    StartCoroutine(ReloadRifleCoro());
                    break;
                case Weapon.sniper:
                    sniperAmmoCount = 0;
                    sniperReloadTime = sniperReload;
                    print(sniperReload);
                    myAnim.SetFloat("reloadMultiplier",3.3f/sniperReload );
                    myAnim.SetBool("reloading", true);
                    reloadingSniper = true;
                    StartCoroutine(ReloadSniperCoro());
                    break;
            }
        }
    }

    IEnumerator ReloadRifleCoro()
    {
        print("reloading");
        while (rifleReloadTime > 0)
        {
            if (selectedWeapon == Weapon.rifle)
            {
                rifleReloadTime -= Time.deltaTime;
            }
            yield return null;
        }
        myAnim.SetBool("reloading", false);
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
        myAnim.SetBool("reloading", false);
        sniperAmmoCount = sniperAmmoMax;
        reloadingSniper = false;
    }
    #endregion
    void WeaponSecondaries()
    {
        if (Input.GetMouseButton(1))
        {

            switch (selectedWeapon)
            {
                case Weapon.rifle:
                    if (gotGL)
                    {
                        gL.InvokeToRun(cam);
                    }
                    break;
                case Weapon.sniper:
                    if (gotSL && !sniperLaserActive)
                    {
                        sL.InvokeToRun();
                    }
                    break;
            }
        }
    }
    #endregion

    void LoadStatScreen()
    {
        //print(StatScreenLoader.playerInZone);
        if (StatScreenLoader.playerInZone && Input.GetKeyDown(KeyCode.BackQuote))
        {
            playerLocked = true;
            SceneManager.LoadScene(1,LoadSceneMode.Additive);
            cam.gameObject.SetActive(false);
            myCanvas.SetActive(false);
        }
    }
    
    public void UnlockPlayer()
    {
        if (playerLocked)
        {
            playerLocked = false;
        }
    }
    public void LockPlayer()
    {
        playerLocked = true;
    }

    void ActiveAbilityInput()
    {
        if (Input.GetKey(KeyCode.Q) && PlayerManager.pM.qAbility != null)
        {
            PlayerManager.pM.qAbility.InvokeToRun(); 
        }
        if (Input.GetKey(KeyCode.E) && PlayerManager.pM.eAbility != null)
        {
            PlayerManager.pM.eAbility.InvokeToRun();
        }
    }

    public void ImpulseThusterChange(float moveIncrease, float diveStandIncrease, float SprintChangeIncrease)
    {
        moveSpeed += moveIncrease;
        diveStandDelay += diveStandIncrease;
        sprintSpeedChange += SprintChangeIncrease;
    }

    public void JuggernaughtChange(float movedecrease, float SprintChangeDecrease)
    {
        moveSpeed -= movedecrease;
        sprintSpeedChange += SprintChangeDecrease;
    }

    public void OverchargeChange(float moveIncrease, float diveStandIncrease, float SprintChangeIncrease)
    {
        moveSpeed += moveIncrease;
        diveStandDelay += diveStandIncrease;
        sprintSpeedChange += SprintChangeIncrease;
    }

    void AimGun()
    {
        if (!sprinting || shooting && !diving)
        {
            RaycastHit camCast;
            Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 40, 1 << 12);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.Atan2(-(camCast.point - transform.position).z, (camCast.point - transform.position).x) * Mathf.Rad2Deg + 90, transform.rotation.eulerAngles.z);
        }
    }

}
