using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
    //Handles the A* lofic 

    //public GameObject startPos; //start posistion of path
   // public GameObject endPos; //end posisition of path
   
   public Grid grid; //grid reference
    
    private void Awake()
    {
        grid = FindObjectOfType<Grid>().GetComponent<Grid>(); //get the grid attached
       
    }
    
    private void FixedUpdate()
    {
      // FindPath(startPos.transform.position, endPos.transform.position); //find our path
    }

    public List<Node> FindPath(Vector3 startPos, Vector3 endPos)
    {
        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();
        //openList.Clear(); //clear the open list
        //closedList.Clear(); //clear the closed list
        Node startNode = grid.NodePoint(startPos); //get the node of the start point
        Node endNode = grid.NodePoint(endPos); //get the node of the end point
      
        openList.Add(startNode); //begin pathfinding
        
        while (openList.Count > 0) //while loop for path finding
        {
            Node currentNode = openList[0]; //make the current node the first node in open list
    
            for (int i = 1; i < openList.Count; i++) //iterate through all nodes in open list
            {
              
                if (openList[i].fVal < currentNode.fVal || openList[i].fVal == currentNode.fVal && openList[i].hVal < currentNode.hVal) //if the f cost of the current node is greater than the nodes in open list
                {
                   currentNode = openList[i]; //set current node into the open list
                    
                }
            }

            openList.Remove(currentNode); //remove the current node from open list
            closedList.Add(currentNode); //add the current node to closed list

            if (currentNode == endNode) //if the current node is the end node
            {                               
                return FindOptimalPath(startNode, endNode);//our pathfind is complete and we show path 
            }

            foreach (Node neighbour in grid.FindNeighbours(currentNode)) //finding neighbours of current node
            {
               
                
                if (neighbour.isObstacle || neighbour.isAgent || neighbour.isBuilding || closedList.Contains(neighbour)) //if the neighbour node is an obnstacle or not in close list
                {
                    
                    continue;
                    
                }

                int gCost = currentNode.gVal + GetChebyshevDistance(currentNode, neighbour); //find the g cost of current node
              
                if (gCost < neighbour.gVal ||!openList.Contains(neighbour)) { //if the gcost is less than its neighbours
                    neighbour.gVal = gCost; //set the neightbours gcost
                    neighbour.hVal = GetChebyshevDistance(neighbour, endNode); //get the neighbours hcost
                    neighbour.Parent = currentNode; //set the parent for potential optimal pathfinding
                    
                    if (!openList.Contains(neighbour)) //if this neighbour is not in openlist
                   
                    openList.Add(neighbour); //add it
                    
                }              
            }
        }
        return null;
    }

    int GetChebyshevDistance(Node node1, Node node2) //function for returning the distance between 2 nodes (with diagonal movement)
    {
        int mx = Mathf.Abs(node1.xVal - node2.xVal);
        int my = Mathf.Abs(node1.yVal - node2.yVal);

       int h = 10 * (mx + my) - 6 * Mathf.Min(mx, my);
       
       //return Mathf.Max(mx , my);
       return h;
    }
  

    public List<Node> FindOptimalPath(Node _startNode, Node _endNode) //for when the path is found
    { 
        List<Node> OptimalPath = new List<Node>(); //new list for path
        Node CurrentNode = _endNode; // make the current node the goal

        while (CurrentNode != _startNode) //while current isnt the start
        {
            OptimalPath.Add(CurrentNode); //make a chain of the nodes
            CurrentNode = CurrentNode.Parent;
        }
        OptimalPath.Reverse(); // reverse the chain
      

        //grid.OptimalPath = OptimalPath; //show the path
        return OptimalPath;
    }


}


