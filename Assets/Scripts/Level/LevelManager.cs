using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool _debugGizmos;

    private LevelGraph levelGraph = new LevelGraph(25,25); // TODO BAD!!!
    List<Node> path;
    // Start is called before the first frame update
    void Start()
    {
        _debugGizmos = true;
        // levelGraph = new LevelGraph(25, 25);
        path = Pathfind.Astar(levelGraph, levelGraph.GetNode(0,23), levelGraph.GetNode(11, 0));

        Debug.Log((levelGraph));
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public LevelGraph GetLevelGraph()
    {
        if (this.levelGraph is not null)
        {
            return this.levelGraph;
        }
        else
        {
            Debug.Log("null levelGraph");
            return null;
        }
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
