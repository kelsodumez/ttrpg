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
        lGraph = levelManager.GetInstanceLevelGraph();
        SpawnAgent(lGraph.GetNode(15, 15));


    }
    void Update()
    {

    }

    public GameObject SpawnAgent(Node spawnPos)
    {
        GameObject spawnedAgent = Instantiate(agent, Vector3.zero, Quaternion.identity);
        spawnedAgent.GetComponent<AgentMove>().SetPos(spawnPos);
        return spawnedAgent;
    }

}
