using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletLogic : MonoBehaviour
{
    public LineRenderer lR;

    int collisionMask = (1 << 10) | (1 << 11) | (1 << 13);

    Vector3 startPoint;
    Vector3 originPoint;
    Vector3 endPoint;
    Vector3 DirectionVector;
    Vector3[] newLinePos;
    DamagePackage BulletDamage;

    public void StartBullet(Vector3 playerPos, Vector3 shootPoint, float range, DamagePackage myDamagePackage)
    {
        startPoint = playerPos;
        originPoint = playerPos;
        // finds the end point based on bullets trajectory and range
        endPoint = playerPos + (shootPoint - playerPos).normalized * range;

        //unit vector of the bullets trajectory
        DirectionVector = (shootPoint - playerPos).normalized;
        BulletDamage = myDamagePackage;

        //first move
        Vector3[] newLinePos = new Vector3[2];
        newLinePos[0] = startPoint;
        newLinePos[1] = startPoint + DirectionVector * 0.3f;
        startPoint = newLinePos[1];
        lR.SetPositions(newLinePos);
    }

    private void FixedUpdate()
    {
        if ((startPoint - originPoint).magnitude < (endPoint-originPoint).magnitude)
        {
            newLinePos = new Vector3[2];
            newLinePos[0] = startPoint;
            newLinePos[1] = startPoint + DirectionVector * 0.5f;
            startPoint = newLinePos[1];
            lR.SetPositions(newLinePos);
            //needs line cast and damage logic

            RaycastHit hit;
            //Physics.Linecast(newLinePos[0], newLinePos[0], out hit , 1 << 0);
            Physics.Raycast(newLinePos[0], DirectionVector, out hit, 0.5f, collisionMask);
            if (hit.collider != null)
            {
                switch(hit.collider.gameObject.layer)
                {
                    case 11:
                    case 13:
                    hit.collider.GetComponent<BuildingBasic>().DamageResolution(BulletDamage);
                    break;
                    case 10:
                        hit.collider.GetComponent<UnitMaster>().DamageResolution(BulletDamage);
                    break;
                }
                gameObject.SetActive(false);
            }
            /*
            Physics.Linecast(newLinePos[0], newLinePos[0], out hit , 1 << 0);
            if (hit.collider != null)
            {
                print("hit " + hit.collider.name);
            }
            */
        }
        else
        {
            gameObject.SetActive(false);
        }
    }










}
