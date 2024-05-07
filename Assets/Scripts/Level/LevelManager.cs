using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool _debugGizmos;

    private LevelGraph levelGraph;
    List<Node> path;
    // Start is called before the first frame update
    void Start()
    {
        _debugGizmos = true;
        levelGraph = new LevelGraph(25, 25);
        path = Pathfind.Astar(levelGraph, levelGraph.getGraph()[0,23], levelGraph.getGraph()[11, 0]);
        // Debug.Log(levelGraph.getGraph()[0,0].getNodePos());
        // Debug.Log(levelGraph.getGraph()[15,17].getNodePos());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos() 
    {
        if (!_debugGizmos) { return;}

        Gizmos.color = Color.white;
        foreach (Node node in levelGraph.getGraph())
        {
            Gizmos.DrawSphere(node.getNodePos(), 0.25f);
        }
        Gizmos.color = Color.blue;
        foreach (Node node in path)
        {
            Gizmos.DrawSphere(node.getNodePos(), 0.3f);
        }
    }
}
