using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBrain : MonoBehaviour
{
    private List<AgentBrain> otherAgents; // other agents in room
    private AgentMove agentMove;
    private LevelManager levelManager;
    private LevelGraph lGraph;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = levelManager.GetInstanceLevelGraph();

        agentMove = transform.GetComponent<AgentMove>();
        agentMove.MoveAgent(lGraph.GetNode(25,25));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
