using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    private LevelManager lManager;
    private LevelGraph lGraph;
    [SerializeField] private Vector3[] patrolVectors;


    void Start()
    {
        lManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = lManager.GetInstanceLevelGraph();
    }

    private Node GetNextPatrolNode(Vector3 currentPos)
    {
        
    } 
}
