using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    private Node agentPos;
    private LevelManager levelManager;
    private LevelGraph lGraph;

    void Start() 
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = levelManager.GetLevelGraph();

    }
    
    public AgentMove(Node startPos)
    {
        SetPos(startPos);
    }

    public Node getNode()
    {
        return agentPos;
    }

    private void SetPos(Node pos)
    {
        transform.position = pos.getNodePos();
        agentPos = pos;

    }
    public void MoveAgent(Node goalPos)
    {
        List<Node> path = Pathfind.Astar(lGraph, agentPos, goalPos);
        foreach (Node node in path)
        {
            SetPos(node);
        }
    }
}