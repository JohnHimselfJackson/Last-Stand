using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : ActiveAbility
{
    float glRange = 16;
    GameObject grenade;
    int collisionLayer = (1 << 8) | (1 << 10) | (1 << 11) | (1 << 12) | (1 << 13);

    void Awake()
    {
        stringName = "Grenade Launcher";
        descritption = "shoots out a short-range grenade at a location of your choosing";
        cooldown = 8;
        cooldownCount = 0;
    }

    private void Start()
    {
        grenade = PlayerPrefabReferences.PPR.grenade;
    }

    public override void InvokeToRun(Camera playerCam)
    {
        RaycastHit camCast;
        if (cooldownCount <= 0)
        {
            Physics.Raycast(playerCam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 40, 1 << 12);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Mathf.Atan2(-(camCast.point - transform.position).z, (camCast.point - transform.position).x) * Mathf.Rad2Deg + 90, transform.rotation.eulerAngles.z);

            Physics.Raycast(playerCam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 100, 1 << 12);
            // position off grid
            Vector3 shootPoint = camCast.point;
            if((shootPoint - transform.position).magnitude < glRange)
            {
                Debug.DrawLine(transform.position, shootPoint, Color.green, 1f);

            }
            else
            {
                Debug.DrawLine(transform.position, shootPoint, Color.red, 1f);

                RaycastHit grenPos;
                Vector3 grenadeSecondPos = transform.position + (shootPoint - transform.position).normalized * glRange;
                Physics.Raycast(grenadeSecondPos + Vector3.up * 15f, Vector3.down, out grenPos, 30f, collisionLayer);
            }
            Debug.DrawLine(transform.position, shootPoint, Color.red, 1f);
            GameObject shot = PlayerProjectilePool.playerPool.GetObject();

            //shoot code here
            //GameObject tempGrenade = Instantiate(grenade, transform.position, transform.rotation);
            cooldownCount = cooldown;
        }
    }

}
