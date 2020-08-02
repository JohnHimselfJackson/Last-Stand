using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    //base class for the nodes

    public int xVal; //nodes x val
    public int yVal; //nodes y val

    public bool isObstacle; //if the node is an obstacle or not
    public Vector3 nodePos; //the world pos of the node
    public bool isAgent;
    public Node Parent; //each node has a parent which they are connected too

    public int gVal; //the g cost

    public int hVal; //the h cost

    public int fVal { get { return gVal + hVal; } } //the f cost

    public Node(bool n_isAgent,bool n_isObstacle,Vector3 n_Pos, int n_xVal, int n_yVal) //node constructor
    {
        isAgent = n_isAgent;
        isObstacle = n_isObstacle;
        nodePos = n_Pos;
        xVal = n_xVal;
        yVal = n_yVal;

    }

}
