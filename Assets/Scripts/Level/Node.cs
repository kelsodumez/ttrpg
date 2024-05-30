using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node
{
    private Vector3 nodePos;
    private float cost;
    private GameObject content; 


    public Node(Vector3 nodePos, float cost)
    {
        setNodePos(nodePos);
        setCost(cost);
    }

    public void setNodePos(Vector3 newPos)
    {
        this.nodePos = newPos;
    }
    
    public Vector3 getNodePos()
    {
        return this.nodePos;
    }

    public void setCost(float newCost)
    {
        this.cost = newCost;
    }

    public float getCost()
    {
        return this.cost;
    }

    public void SetContent(GameObject newContent)
    {
        if (content is null)
        {
            content = newContent;
        }
    }

    public void ClearContent()
    {
        content = null;
    }

    public GameObject GetContent()
    {
        return content;
    }

    public bool IsAtPos(Vector3 pos)
    {
        return nodePos == pos;
    }
}
