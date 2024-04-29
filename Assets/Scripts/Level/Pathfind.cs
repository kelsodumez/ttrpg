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
        totalCost += 1;

        Dictionary<Node, Node> visitedNodes = new();
        Dictionary<Node, float> accumulatedCost = new();
        SimplePriorityQueue<Node, float> nodesToVisit = new SimplePriorityQueue<Node,float>();

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
        }

        foreach (Node adjNode in lGraph.GetNeighbours(currentNode))
        {
            if (!visitedNodes.ContainsKey(adjNode))
            {
                float newCost = accumulatedCost[currentNode] + lGraph.NextMinimumCost(adjNode);

                if(!accumulatedCost.ContainsKey(adjNode) || newCost < accumulatedCost[adjNode])
                {
                    accumulatedCost.Add(adjNode, newCost);
                    visitedNodes[adjNode] = currentNode;

                    float dist = Vector2.Distance(adjNode.getNodePos(), goalNode.getNodePos());
                    float priority = newCost + dist;
                    nodesToVisit.Enqueue(adjNode, priority);
                    totalCost += newCost;
                }
            }
        }
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = visitedNodes[currentNode];
        }
        Debug.Log(path.Count);
        path.Reverse();
        return path;
    }

}
