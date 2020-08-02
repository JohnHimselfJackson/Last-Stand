using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour //the agent(fish) class
{


    public Astar a;
    public Grid g;
    public GameObject end;
    public Collider myCollider; //a reference for the collider on the entity
    bool isNewDirect;
    Vector3 directVect;
    GameObject astar;
    bool ticking;
    List<Node> myPath;
    public void start()
    {
        end = GameObject.FindGameObjectWithTag("Player");//finding the player clone in the scene
        a = GameObject.Find("aStar").GetComponent<Astar>();
        g = GameObject.FindGameObjectWithTag("aStar").GetComponent<Grid>();
     

        
    }
    public void Update()
    {
       // MoveAgent(end.transform.position);
    }
    public void MoveAgent(Vector3 goal) //the move function that takes the calculated vector and adjusts entities movement
    {
        myPath = a.FindPath(transform.position, goal);
        if(myPath.Count > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, myPath[1].nodePos, g.nodeRadius / 8);
        }
       
    }

    
 
  

}
