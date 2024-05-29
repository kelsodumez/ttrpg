using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AgentBrain : MonoBehaviour, IActor
{
    private List<AgentBrain> otherAgents; // other agents in room
    private LevelManager levelManager;
    private LevelGraph lGraph;
    private bool agentTurn = false;
    private AgentMove _agentMove;
    private AgentStats _agentStats;
    private GameObject _player;
    [SerializeField] private float _safeDistance = 5f;
    [SerializeField] private float _maxDistance = 10f;
    [SerializeField] private Node[] patrolNodes;
    private bool playerFound = false;

    public float GetActorInititiative()
    {
        return _agentStats.getStat(AgentStats._stats._inititiative);
    }

    public void Init()
    {
        _player = GameObject.Find("Player");
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = levelManager.GetInstanceLevelGraph();
        _agentMove = transform.GetComponent<AgentMove>();
        _agentStats = transform.GetComponent<AgentStats>();
        patrolNodes = new();
        RegisterSelf();
    }
    public void NextActorTurn()
    {
        TurnManager.NextActorTurn();
    }

    public void Pause()
    {
        agentTurn = false;
        NextActorTurn();
    }

    public void RegisterSelf()
    {
        TurnManager.RegisterActor(this, _agentStats.getStat(AgentStats._stats._inititiative));
    }

    public void Unpause()
    {
        // agentTurn = true;
        DecideAction();
        // Pause();

        // TODO dont need bool, decide movement -> move -> attack
    }

    private float GetPlayerDistance()
    {
        return Vector3.Distance(transform.position, _player.transform.position);
    }

    private void DecideAction()
    {
        Debug.Log($"{this.name} turn");
        //TODO check if player discovered

        //TODO do a visual check for player with frustums n shit
        //TODO patrol 
        if (playerFound)
        {
            bool cornered = true;
            if (GetPlayerDistance() < _safeDistance)
            {
                cornered = SeekDistanceFromPoint(_player.transform.position, _safeDistance);
            }
            else if (GetPlayerDistance() > _maxDistance)
            {
                CloseDistance(_player.transform.position, _safeDistance);
            }
            //TODO close distance

            if (cornered == true)
            {
                //TODO SHOOT!
            }
            Pause();
        }
        else
        {
            //TODO if view frustum check for player
            Patrol();
        }

    }

    private void Patrol()
    {

    }
    private void CloseDistance(Vector3 point, float dist)
    {
        Node pointNode = lGraph.GetNode((int) point.x, (int) point.z);
        Vector3 pointDirection = (pointNode.getNodePos() - transform.position).normalized;
        Vector3 runTO = pointDirection * dist;
        if (lGraph.InLevelGraph((int) runTO.x, (int) runTO.z))
        {
            Debug.Log("hello");
            NavigateTo(runTO);
        }
    }

    private bool SeekDistanceFromPoint(Vector3 point, float dist)
    {
        //normally is dest - orig, need to do orig - dist for opp direction
        Vector3 oppositeDirection = _agentMove.getNode().getNodePos() - lGraph.GetNode((int) point.x, (int) point.z).getNodePos();
        float distDiff = Mathf.Abs(dist - Vector3.Distance(_agentMove.getNode().getNodePos(), lGraph.GetNode((int) point.x, (int) point.z).getNodePos()));
        //get distance between point and object, subtract it from distance to find the distance required to travel
        // Debug.Log(oppositeDirection * distDiff);
        Vector3 runTo = oppositeDirection * distDiff;
        // TODO check if node valid
        if (lGraph.InLevelGraph((int)runTo.x, (int)runTo.z))
        {
            NavigateTo(runTo);
            return false;
        }
        return true;
    }

    private void NavigateTo(Vector3 point)
    {
        Node goalNode = lGraph.GetNode((int) point.x, (int) point.z);
        List<Node> path = Pathfind.Astar(lGraph, _agentMove.getNode(), goalNode);
        if (path.Count > _agentStats.getStat(AgentStats._stats._moveSpeed))
        {
            goalNode = path[(int) AgentStats._stats._moveSpeed];
        }
        _agentMove.MoveAgent(goalNode);
    }
}
