using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LevelGraph levelGraph;
    List<Node> path;
    // Start is called before the first frame update
    void Start()
    {
        levelGraph = new LevelGraph(25, 25);
        path = Pathfind.Astar(levelGraph, new Node(Vector3.zero, 0), new Node(new Vector3(19, 0, 23), 0));
        Debug.Log(path.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos() 
    {
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
