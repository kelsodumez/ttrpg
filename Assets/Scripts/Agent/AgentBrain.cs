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
        Pause();
        // TODO dont need bool, decide movement -> move -> attack
    }

    private float GetPlayerDistance()
    {
        return Vector3.Distance(transform.position, _player.transform.position);
    }

    private void DecideAction()
    {
        if (GetPlayerDistance() < _safeDistance)
        {
            SeekDistanceFromPoint(_player.transform.position, _safeDistance);
        }
    }

    private void SeekDistanceFromPoint(Vector3 point, float dist)
    {
        for (int i =0; i < 360; i++)
        {
            if (Mathf.RoundToInt(point.x+dist*Mathf.Cos(Mathf.Deg2Rad * i)) == point.x)
            {
                Debug.Log(i);
            }
        }
    }

    private void NavigateTo()
    {
        Debug.Log($"{this.name} turn");
        // _agentMove.MoveAgent()
    }
}
