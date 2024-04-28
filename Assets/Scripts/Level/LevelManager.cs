using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private LevelGraph levelGraph;
    // Start is called before the first frame update
    void Start()
    {
        levelGraph = new LevelGraph(25, 5, 25);
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
    }
}
