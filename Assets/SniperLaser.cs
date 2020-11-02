using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperLaser : ActiveAbility
{
    PlayerController pC;
    float laserRange;
    GameObject laser;
    int collisionLayer = (1 << 8) | (1 << 10) | (1 << 11) | (1 << 12) | (1 << 13);
    GameObject activeLaser;
    Camera playerCam;

    void Awake()
    {
        pC = GetComponent<PlayerController>();
        stringName = "Sniper Laser";
        descritption = "shoots a laser from your sniper laser";
        cooldown = 12;
        cooldownCount = 0;
    }

    private void Start()
    {
        laserRange = PlayerManager.pM.pC.sniperRange;
        laser = PlayerPrefabReferences.PPR.laser;
        playerCam = PlayerManager.pM.pC.cam;
    }

    public override void InvokeToRun()
    {
        if (cooldownCount <= 0 && activeLaser == null)
        {
            pC.sniperLaserActive = true;
            activeLaser = Instantiate(laser);           

            Invoke("EndLaser", 4f);
        }
    }

    void UpdateLaser()
    {
        RaycastHit camCast;
        Physics.Raycast(playerCam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 40, 1 << 12);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.Atan2(-(camCast.point - transform.position).z, (camCast.point - transform.position).x) * Mathf.Rad2Deg + 90, transform.rotation.eulerAngles.z);

        Physics.Raycast(playerCam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 100, 1 << 12);
        // position off grid
        Vector3 shootPoint = camCast.point;
        if ((shootPoint - transform.position).magnitude < laserRange)
        {
        }
        else
        {
            RaycastHit grenPos;
            Vector3 laserSecondPos = transform.position + (shootPoint - transform.position).normalized * laserRange;
            Physics.Raycast(laserSecondPos + Vector3.up * 15f, Vector3.down, out grenPos, 30f, collisionLayer);
        }
        shootPoint = shootPoint + Vector3.up;
        Vector3 laserEndPoint = transform.position + (shootPoint - transform.position).normalized * laserRange;
        activeLaser.GetComponent<LaserComponent>().LaserFunction(transform.position, laserEndPoint);
    }

    public void EndLaser()
    {
        pC.sniperLaserActive = false;
        cooldownCount = cooldown;
        Destroy(activeLaser);
    }

    private void Update()
    {
        if (cooldownCount > 0)
        {
            cooldownCount -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (activeLaser != null)
        {
            UpdateLaser();
        }
    }
}
