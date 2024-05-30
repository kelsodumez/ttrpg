using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawn : MonoBehaviour
{
    [SerializeField] private GameObject agent;
    private LevelManager levelManager;
    private LevelGraph lGraph;
    [SerializeField] private List<Vector3> spawnLocations; 
    [SerializeField] private bool drawGizmos = true;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = levelManager.GetInstanceLevelGraph();

        foreach (Vector3 spawnLocation in spawnLocations)
        {
            SpawnAgent(lGraph.GetNode((int) spawnLocation.x, (int) spawnLocation.z));
        }
    }
    void Update()
    {

    }

    public GameObject SpawnAgent(Node spawnPos)
    {
        GameObject spawnedAgent = Instantiate(agent, Vector3.zero, Quaternion.identity);
        spawnedAgent.GetComponent<AgentMove>().SetPos(spawnPos);
        spawnedAgent.GetComponent<AgentBrain>().SetPatrolRoute(transform.GetComponent<PatrolRoute>());
        spawnedAgent.GetComponent<AgentBrain>().Init();
        return spawnedAgent;
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.color = Color.green;
            foreach(Vector3 spawnLocation in spawnLocations)
            {
                Gizmos.DrawCube(spawnLocation, new Vector3(.8f,.8f,.8f));
            }
        }
    }   
}
