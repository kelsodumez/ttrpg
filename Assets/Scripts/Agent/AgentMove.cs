using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    private Node agentPos;
    private LevelManager levelManager;
    private LevelGraph lGraph;
    [SerializeField] float moveTime = .1f;
    [SerializeField] float moveLerpRate = .1f;

    private bool destReached = false;

    void Start() 
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = levelManager.GetInstanceLevelGraph();

    }
    
    public AgentMove(Node startPos)
    {
        SetPos(startPos, true);
    }

    public Node getNode()
    {
        return agentPos;
    }

    public void SetPos(Node pos, bool instant)
    {
        if (instant)
        {
            transform.position = pos.getNodePos();
            agentPos = pos;
        }
        else
        {
            
        }
    }

    public void MoveAgent(Node goalPos)
    {
        List<Node> path = Pathfind.Astar(lGraph, agentPos, goalPos);
        foreach (Node node in path)
        {
            //TODO need to wait for full traversal between nodes before going to next node
            SetPos(node, false);
        }
    }
}