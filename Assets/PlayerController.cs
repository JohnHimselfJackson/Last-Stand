using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;

    private bool forwards, backwards, left, right;

    public float ammoCount { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimShoot();
    }

    //returns movement direction as vector 3
    Vector3 DirectionalMovement()
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
        //find point
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit camCast;
            Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono), out camCast, 40, 1 << 8);
            // position off grid
            Vector3 shootPoint = camCast.point + Vector3.up;
            Debug.DrawLine(transform.position, shootPoint, Color.red, 0.1f);
            GameObject shot = PlayerProjectilePool.playerPool.GetObject();
            print(shootPoint);
            DamagePackage dP = new DamagePackage(DamagePackage.damageClass.Light, DamagePackage.damageType.standard,12);
            shot.GetComponent<PlayerBulletLogic>().StartBullet(gameObject.transform.position,shootPoint, 12, dP);
            shot.SetActive(true);
        }
        //Shoot ray
    }
}
