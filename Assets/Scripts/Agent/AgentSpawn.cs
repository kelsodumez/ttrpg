using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawn : MonoBehaviour
{
    [SerializeField] private GameObject agent;
    private LevelManager levelManager;
    private LevelGraph lGraph;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = levelManager.GetLevelGraph();

        Debug.Log((lGraph));


    }
    void Update()
    {
        GameObject spawnedAgent = SpawnAgent(lGraph.GetNode(0, 0));
        spawnedAgent.GetComponent<AgentMove>().MoveAgent(lGraph.GetNode(10,0));
    }

    public GameObject SpawnAgent(Node spawnPos)
    {
        Debug.Log("reach");
        GameObject spawnedAgent = Instantiate(agent, spawnPos.getNodePos(), Quaternion.identity);
        Debug.Log(spawnedAgent);
        return spawnedAgent;
    }

}
