using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserComponent : MonoBehaviour
{
    public LineRenderer lR;

    int collisionMask = (1 << 8) | (1 << 10) | (1 << 11) | (1 << 12) | (1 << 13);

    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 DirectionVector;
    Vector3[] newLinePos;
    DamagePackage laserDamage;
    // Start is called before the first frame update
    void Awake()
    {
        laserDamage = new DamagePackage(DamagePackage.damageClass.light, DamagePackage.damageType.trueDamage, 2, 0.05f);
        lR = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    public void LaserFunction(Vector3 startPoint, Vector3 endPoint)
    {
        Vector3[] newLinePos = new Vector3[2];
        newLinePos[0] = startPoint;
        newLinePos[1] = endPoint;
        Debug.DrawLine(newLinePos[0], newLinePos[1], Color.blue, 0.1f);
        lR.SetPositions(newLinePos);

        RaycastHit hit;
        Ray laserRay = new Ray(startPoint, endPoint - startPoint);
        Physics.Raycast(laserRay, out hit, (endPoint - startPoint).magnitude, collisionMask);
        if (hit.collider != null)
        {
            switch (hit.collider.gameObject.layer)
            {
                case 11:
                case 13:
                    hit.collider.GetComponent<BuildingBasic>().DamageResolution(laserDamage);
                    break;
                case 10:
                    hit.collider.GetComponent<UnitMaster>().DamageResolution(laserDamage);
                    break;
            }
        }
    }
}
