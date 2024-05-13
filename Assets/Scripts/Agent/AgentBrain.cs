using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBrain : MonoBehaviour, IActor
{
    private List<AgentBrain> otherAgents; // other agents in room
    private LevelManager levelManager;
    private LevelGraph lGraph;
    private bool agentTurn = false;
    private AgentMove _agentMove;
    [SerializeField] private float _agentSpeed = 1f;

    public float GetActorSpeed()
    {
        return _agentSpeed;
    }

    public void Init()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        RegisterSelf();
        lGraph = levelManager.GetInstanceLevelGraph();
        _agentMove = transform.GetComponent<AgentMove>();
        
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
        TurnManager.RegisterActor(this, _agentSpeed);
    }

    public void Unpause()
    {
        // agentTurn = true;
        Move();
        Pause();
        // TODO dont need bool, decide movement -> move -> attack
    }
    private void Move()
    {
        Debug.Log($"{this.name} turn");
        // _agentMove.MoveAgent()
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
