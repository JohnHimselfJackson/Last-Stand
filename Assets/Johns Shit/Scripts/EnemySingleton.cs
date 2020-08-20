using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySingleton : MonoBehaviour
{
    public static EnemySingleton main;

    public bool firstBaseAlive = true;
    public bool secondBaseAlive = true;
    public bool thirdBaseAlive = true;
    //locations of three key buildings
    public Vector3 firstLoc;
    public Vector3 secondLoc;
    public Vector3 thirdLoc;


    // Start is called before the first frame update
    void Awake()
    {
        if(main == null)
        {
            main = this;
        }
        else
        {
            print("a second enemy singleton existed: Original = " + main.gameObject.name + " - Second: " + gameObject.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
