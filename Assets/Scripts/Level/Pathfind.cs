using System.Collections;
using System.Collections.Generic;
using Priority_Queue;
using UnityEngine;

public class Pathfind
{
    private static float totalCost = 0;
    public static List<Node> Astar(LevelGraph lGraph, Node startNode, Node goalNode)
    {
        List<Node> path = new List<Node>();
        totalCost = 0;

        Dictionary<Node, Node> visitedNodes = new();
        Dictionary<Node, float> accumulatedCost = new();
        SimplePriorityQueue<Node> nodesToVisit = new SimplePriorityQueue<Node>();

        nodesToVisit.Enqueue(startNode, 0);
        visitedNodes.Add(startNode, startNode);
        accumulatedCost.Add(startNode, 0);

        Node currentNode = new Node(Vector3.zero, 0);

        while (nodesToVisit.Count > 0)
        {
            currentNode = nodesToVisit.Dequeue();
            if (currentNode == goalNode)
            {
                break;
            }

            foreach (Node adjNode in lGraph.GetNeighbours(currentNode))
            {
                // if the node has not been visited
                if (!visitedNodes.ContainsKey(adjNode))
                {
                    float newCost = accumulatedCost[currentNode] + lGraph.NextMinimumCost(adjNode);

                    if(!accumulatedCost.ContainsKey(adjNode) || newCost < accumulatedCost[adjNode])
                    {
                        accumulatedCost.Add(adjNode, newCost);
                        visitedNodes[adjNode] = currentNode;

                        float dist = Vector2.Distance(new Vector2(adjNode.getNodePos().x, adjNode.getNodePos().z), new Vector2(goalNode.getNodePos().x, goalNode.getNodePos().z));
                        float priority = newCost + dist;
                        nodesToVisit.Enqueue(adjNode, priority);
                        
                        totalCost += newCost;
                    }
                }
            }
        }


        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = visitedNodes[currentNode];
        }
        path.Reverse();
        return path;
    }

}
