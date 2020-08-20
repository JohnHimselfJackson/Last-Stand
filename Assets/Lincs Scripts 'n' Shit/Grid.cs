using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour{ 

    public GameObject player; //start posistion of the path
    
    public LayerMask obstacleLayer; //the obstacle layer
    public LayerMask playerLayer; //the obstacle layer
    public LayerMask buildingLayer; //the obstacle layer
    public Vector2 gridWorldSize; //the size of the grid 
    public float nodeRadius; // size of the nodes
    public float distance; //distance of nodes
    int gridX; //how many nodes on x axis
    int gridY; //how many nodes on y axis
    Node[,] grid; //an array of nodes
    public List<Node> OptimalPath; //the path
    

    void Awake() //create the grid
    {

        gridX = Mathf.RoundToInt(gridWorldSize.x / (2 * nodeRadius));
        gridY = Mathf.RoundToInt(gridWorldSize.y / (2 * nodeRadius));
        GridCreation();
    }

    public void Update()
    {
        GridCreation();
    
    }

    public void GridCreation() //function that creates grid over an area, checks for obstacles
    {
        grid = new Node[gridX, gridY]; // new node array of the size of the grid
        

        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2; // finding the bottom left or first element of the grid

        for (int x = 0; x <gridX; x++)
        {

            for(int y = 0; y < gridY; y++) //nested for loop to iterate through all node postitions
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeRadius * 2 + nodeRadius) + Vector3.forward * (y * nodeRadius * 2 + nodeRadius); //to check every node point
                bool isObstacle = false;
                bool isAgent = false;
                bool isBuilding = false;
                if (Physics.CheckSphere(worldPoint, nodeRadius, playerLayer))
                { //if the node is on a obstacle layerd gameobject
                    isAgent = true; //sets node to an obstacle
                }

                if (Physics.CheckSphere(worldPoint, nodeRadius, obstacleLayer)){ //if the node is on a obstacle layerd gameobject
                    isObstacle = true; //sets node to an obstacle
                }
                if (Physics.CheckSphere(worldPoint, nodeRadius, buildingLayer))
                { //if the node is on a obstacle layerd gameobject
                    isBuilding = true; //sets node to an obstacle
                }

                grid[x, y] = new Node(isAgent,isObstacle,isBuilding, worldPoint, x, y); //add the node to the array
            }
           
        }
    }

    public Node NodePoint(Vector3 worldPoint) //function to find the node from the world posistion
    {
        float percentX = ((worldPoint.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float percentY = ((worldPoint.z + gridWorldSize.y / 2) / gridWorldSize.y);
        percentX = Mathf.Clamp01(percentX); //clamps % inbetween 0 and 1
        percentY = Mathf.Clamp01(percentY); //clamps % inbetween 0 and 1

        int x = Mathf.RoundToInt((gridX - 1) * percentX); //finding exact x posistion rounded to node size
        int y = Mathf.RoundToInt((gridY - 1) * percentY); //finding exact y posistion rounded to node size


        return grid[x, y]; //return the node
    }

    public Node[] NodeArea(Vector3 worldPoint , GameObject objectCheck) //function to find the node from the world posistion
    {
        Node[] nodeAreaArray = new Node[2];
        MeshRenderer renderer = objectCheck.GetComponent<MeshRenderer>();
        Vector3 size = renderer.bounds.size;
        //
        for(int i=0;i<= 2; i++)
        {
            nodeAreaArray[i] = NodePoint(new Vector3(size.x, worldPoint.y, worldPoint.z));
        }
       
     

        return nodeAreaArray; //return the node array
    }

    public List<Node> FindNeighbours(Node node) //function to find the neighbours of any given node
    {
        List<Node> nodeNeighbours = new List<Node>(); //make a neighbour node list
        for(int x = -1; x<= 1; x++)
        {
            for (int y = -1; y <= 1; y++) //nested for loop to iterate through 9 nodes
            {
                if(x==0 && y == 0)
                {
                    continue; //the current node
                }
                int checkX = node.xVal + x;
                int checkY = node.yVal + y;
                if(checkX >=0 && checkX <gridX && checkY >= 0 && checkY < gridY) //if the checked node is next to current node
                {
                    nodeNeighbours.Add(grid[checkX, checkY]);//add the neighbour nodes to list
                }
            }
        }
        return nodeNeighbours; //return neighbour list
    }
   
    
    private void OnDrawGizmos() //draws the grid
    {
 
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 0, gridWorldSize.y)); //draw a wire grid with correct dimensions

        if (grid != null ) //if the grid is not empty
        {
          // Node playerNode = NodePoint(player.transform.position); //create a reference for the start node
            //Node endNode = NodePoint(endPos.transform.position); //create a reference for the end node
          
            foreach (Node node in grid) //iterate through all nodes
            {
             
               

          
                if (!node.isObstacle) //if node is not an obstacle
                {
                    Gizmos.color = Color.white;  //set the colour to white      
                }
        
                else
                {
                   
                    Gizmos.color = Color.red; //if it is obstacle set the nodes colour to red
                }
            
                if (node.isBuilding) //if node is not an obstacle
                {
                    Gizmos.color = Color.blue;  //set the colour to white      
                }
                //for (int i = 0; i < OptimalPath.Count; i++)
                //{
                //    if (node.nodePos == OptimalPath[i].nodePos)
                //    {
                //        Gizmos.color = Color.green;
                //    }
                //}


                Gizmos.DrawWireCube(node.nodePos, Vector3.one * (nodeRadius * 2 - distance)); //draw the node
            }
          
            
            
        }
    }
}
