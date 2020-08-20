using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject unit;
    public int maxSpawn;
    public int spawn;

    public Transform spawnPont;
    //variables
    public Transform rallyPoint;

    private float nextActionTime = 0.0f;
    public float period = 3f;

    void Start()
    {
        nextActionTime -= Time.time;
        spawn = 0;
    }
    void Update()
    {
        if (spawn < maxSpawn)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;


                Instantiate(unit, spawnPont.position, Quaternion.identity);


                spawn++;
            }
        }


    }


    // Update is called once per frame

}
