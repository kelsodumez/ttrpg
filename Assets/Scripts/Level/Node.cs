using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private Vector3 nodePos;
    private float cost;

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
}
