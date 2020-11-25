using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLogic : MonoBehaviour
{
    public LineRenderer lR;

    int collisionMask = (1 << 9) ;

    Vector3 startPoint;
    Vector3 originPoint;
    Vector3 endPoint;
    Vector3 DirectionVector;
    Vector3[] newLinePos;
    DamagePackage BulletDamage;

    public void StartBullet(Vector3 enemyPos, Vector3 shootPoint, float range, DamagePackage myDamagePackage)
    {
        startPoint = enemyPos;
        originPoint = enemyPos;
        // finds the end point based on bullets trajectory and range
        endPoint = enemyPos + (shootPoint - enemyPos).normalized * range;

        //unit vector of the bullets trajectory
        DirectionVector = (shootPoint - enemyPos).normalized;
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
                    case 9:
                        hit.collider.gameObject.GetComponent<PlayerManager>().PlayerDamageResolution(BulletDamage);
                        BloodPool.bloodPool.GetObject().GetComponent<ParticleLogic>().StartParticle(hit.point,0.15f);
                        break;
                }
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }










}
