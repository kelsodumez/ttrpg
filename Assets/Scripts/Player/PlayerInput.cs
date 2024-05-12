using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private LevelManager levelManager;
    private LevelGraph lGraph;
    private bool moveSelected = false;
    private AgentMove agentMove;
    bool playerTurn = false;

    private float enter = 0.0f;
    Plane nPlane = new Plane(Vector3.up, Vector3.zero);

    // Start is called before the first frame update
    void Start()
    {
        agentMove = gameObject.GetComponent<AgentMove>();
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        lGraph = levelManager.GetInstanceLevelGraph();

        agentMove.SetPos(lGraph.GetNode((int) transform.position.x, (int) transform.position.z), true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn && moveSelected)
        {
            // TODO enable visual element for selecting where to move, knowing allowance, etc.
            if (Input.GetMouseButtonDown(0))
            {
                Node hitNode = SelectNode();
                agentMove.MoveAgent(hitNode);
                
            }
        }

    }

    public void Move()
    {
        moveSelected = true;
    }

    private Node SelectNode()
    {
        RaycastHit hit;
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (nPlane.Raycast(rayOrigin, out enter))
        {
            Vector3 hitPoint = rayOrigin.GetPoint(enter);
            Debug.Log($"{hitPoint}");
            Node hitNode = lGraph.GetNode(Mathf.RoundToInt(hitPoint.x), Mathf.RoundToInt(hitPoint.z));
            return hitNode;
        }
        return null;
    }

}
