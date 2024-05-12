using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.XR;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool _debugGizmos;

    private LevelGraph levelGraph; // TODO BAD!!!
    List<Node> path;
    [SerializeField] private int levelWidth = 30;
    [SerializeField] private int levelHeight = 30;

    private TimeSchedule _timeSchedule = new();

    [SerializeField] private GameObject _player;

    // Start is called before the first frame update
    void Awake() 
    {
        levelGraph = new LevelGraph(levelWidth, levelHeight);
    }
    
    void Start()
    {
        _debugGizmos = true;
        _timeSchedule.ScheduleEvent(_player, 10); // TODO add speed variable for player
    }

    // Update is called once per frame
    void Update()
    {
        HandleTurns();
    }

    public void HandleTurns()
    {
        GameObject nextMove = _timeSchedule.NextEvent();
        // TODO add stuff for 'unpausing' characters when its their turn
        _timeSchedule.ScheduleEvent(nextMove);
    }
    
    public LevelGraph GetInstanceLevelGraph()
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
        if (!_debugGizmos) return;

        Gizmos.color = Color.white;
        foreach (Node node in levelGraph.getGraph())
        {
            if (node.getCost() == float.PositiveInfinity)
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawSphere(node.getNodePos(), 0.25f);
            Gizmos.color = Color.white;

            
        }
        // Gizmos.color = Color.blue;
        // foreach (Node node in path)
        // {
        //     Gizmos.DrawSphere(node.getNodePos(), 0.3f);
        // }
    }
}
