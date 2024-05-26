using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    private Node agentPos;
    private LevelManager levelManager;
    private LevelGraph lGraph;
    private float moveLerpRate;


    void Start() 
    {
        moveLerpRate = 2f;
        Debug.Log(moveLerpRate);
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = levelManager.GetInstanceLevelGraph();

    }
    
    public AgentMove(Node startPos)
    {
        SetPos(startPos);
    }

    public Node getNode()
    {
        return agentPos;
    }

    public Node GetAgentPos()
    {
        return agentPos;
    }

    public void MoveAgent(Node goalPos)
    {
        List<Node> path = Pathfind.Astar(lGraph, agentPos, goalPos);
        StartCoroutine(LerpThroughNode(path));
        agentPos = goalPos;
    }

    public void SetPos(Node newPos)
    {        
        transform.position = newPos.getNodePos();
        agentPos = newPos;
    }

    IEnumerator LerpThroughNode(List<Node> path)
    {
        float timer = 0;
        Vector3 prevPos = transform.position;

        while (path.Count > 0)
        {
            timer += Time.deltaTime * moveLerpRate;
            transform.position = Vector3.Lerp(prevPos, path[0].getNodePos(), timer);
            if (timer > 1)
            {
                timer = 0;
                prevPos = path[0].getNodePos();
                path.RemoveAt(0);
      
            }           
            yield return new WaitForEndOfFrame();
        }
        transform.GetComponent<IActor>().Pause();
    }


}