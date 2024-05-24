using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    private Node agentPos;
    private LevelManager levelManager;
    private LevelGraph lGraph;
    [SerializeField] float moveTime = 5f;
    [SerializeField] float moveLerpRate = .1f;


    void Start() 
    {
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
        // Debug.Log(goalPos.getNodePos());

        Debug.Log("reach");
        Debug.Log("started");
        StartCoroutine(LerpThroughNode(path));
        Debug.Log("finished");
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
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(prevPos, path[0].getNodePos(), timer);
            // Debug.Log(path.IndexOf(currentNode)/timer);
            if (timer > 1)
            {
                timer = 0;
                prevPos = path[0].getNodePos();
                path.RemoveAt(0);
      
            }            // Debug.Log(path.IndexOf(currentNode));
            // Debug.Log(timer/5);
            yield return new WaitForEndOfFrame();
        }
    }


}