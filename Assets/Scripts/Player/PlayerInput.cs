using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour, IActor
{
    private LevelManager levelManager;
    private LevelGraph lGraph;
    private bool moveSelected = false;
    private AgentMove agentMove;
    bool playerTurn = false;
    bool waitingToSelect = true;

    private float enter = 0.0f;
    Plane nPlane = new Plane(Vector3.up, Vector3.zero);
    private AgentStats _playerStats;
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = transform.GetComponent<AgentStats>();

        agentMove = gameObject.GetComponent<AgentMove>();
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = levelManager.GetInstanceLevelGraph();

        agentMove.SetPos(lGraph.GetNode((int) transform.position.x, (int) transform.position.z));
        RegisterSelf();
    }

    // Update is called once per frame
    void Update()
    {

        // waitingToSelect = false;
        // // TODO enable visual element for selecting where to move, knowing allowance, etc.
        if (playerTurn && waitingToSelect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log($"player turn");
                Node hitNode = SelectNode();
                List<Node> path = Pathfind.Astar(lGraph, agentMove.GetAgentPos(), hitNode);
                if (path.Count >= _playerStats.getStat(AgentStats._stats._moveSpeed))
                {
                    agentMove.MoveAgent(path[(int) _playerStats.getStat(AgentStats._stats._moveSpeed)]);
                }
                else
                {
                    agentMove.MoveAgent(hitNode);
                }
            }
        }
    }

        // Pause();

    public void RegisterSelf()
    {
        TurnManager.RegisterActor(this, _playerStats.getStat(AgentStats._stats._inititiative));
    }

    public void Unpause()
    {
        playerTurn = true;
    }

    public void Pause()
    {
        playerTurn = false;
        waitingToSelect = true;
        NextActorTurn();
    }


    private Node SelectNode()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (nPlane.Raycast(rayOrigin, out enter))
        {
            Vector3 hitPoint = rayOrigin.GetPoint(enter);
            // Debug.Log($"{hitPoint}");
            Node hitNode = lGraph.GetNode(Mathf.RoundToInt(hitPoint.x), Mathf.RoundToInt(hitPoint.z));
            return hitNode;
        }
        return null;
    }

    public void NextActorTurn()
    {
        TurnManager.NextActorTurn();
    }

    public float GetActorInititiative()
    {
        return _playerStats.getStat(AgentStats._stats._inititiative);
    }
}