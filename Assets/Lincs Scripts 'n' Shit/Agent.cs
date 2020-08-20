using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour //the agent
{


    public  Astar a;
    public  Grid g;
    public  GameObject end;
    public List<Node> myPath;
    public UiControl ui;

    public int pathIndex;

    bool moving = false;

    bool atEnd = false;
    public void Start()
    {
        g = GameObject.FindGameObjectWithTag("aStar").GetComponent<Grid>();
        ui = GameObject.FindObjectOfType<Canvas>().GetComponent<UiControl>();
        a = GameObject.FindGameObjectWithTag("aStar").GetComponent<Astar>();
        end = GameObject.FindGameObjectWithTag("Rally0");//finding the player clone in the scene
     

       //  g.OptimalPath = myPath;
    }

    public void FixedUpdate()
    {
        if(myPath == null)
        {
            if (ui.flareActive)
            {
                FindPath(ui.flare.transform.position);
            }
            else
            {
                FindPath(end.transform.position);
            }
        }
        else
        {
            if (ui.flareActive)
            {
                FindPath(ui.flare.transform.position);
            }
        }

        if (!atEnd && myPath != null)
            MoveAgent();
    }

    public void FindPath(Vector3 goal)
    {
        atEnd = false;

        myPath = a.FindPath(transform.position, goal);
       // Debug.Log(myPath.Count);
    }

    public void MoveAgent() //the move function that takes the calculated vector and adjusts entities movement
    {
        moving = true; // flare still calling target pos when at final flare pos
        
        Vector3 targetPos = (myPath[pathIndex].nodePos);

        if(Vector3.Distance(transform.position,targetPos) > g.nodeRadius)
        {
            Vector3 direction = (targetPos - transform.position).normalized;
            transform.position = transform.position + direction * 2f * Time.deltaTime;
        }
        else
        {
            pathIndex++;
            if(pathIndex >= myPath.Count)
            {
                moving = false;
                atEnd = true;
                pathIndex = 0;
            }
        }
    }
}
