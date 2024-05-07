using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGraph
{
    private int levelLength;
    private int levelWidth;
    // private int levelHeight;

    private Node[,] graph;

    public LevelGraph(int levelLength, int levelWidth)//, int levelHeight)
    {
        setLevelLength(levelLength);
        setLevelWidth(levelWidth);
        // setLevelHeight(levelHeight);

        graph = new Node[levelLength, levelWidth];

        for (int x = 0; x < levelLength; x++)
        {
            for (int z = 0; z < levelWidth; z++)
            {
                graph[x, z] = new Node(new Vector3(x, 0, z), 0); //TODO no cost implementation
            }
        }
    }

    public List<Node> GetNeighbours(Node n)
    {
        List<Node> neighbours = new List<Node>();

        Vector2[] directions =
        {
            new Vector2(-1, 0), // west
            new Vector2(-1, 1), // north-west
            new Vector2(0, 1),  // north
            new Vector2(1, 1),  // north-east
            new Vector2(1, 0),  // east
            new Vector2(1, -1), // south-east
            new Vector2(0, -1), // south
            new Vector2(-1, -1) // south-west
        };

        foreach (Vector2 dir in directions)
        {
            Vector2 v = new Vector2(dir.x, dir.y) + new Vector2(n.getNodePos().x, n.getNodePos().z);
            bool doesExist = (v.x >= 0 && v.x < levelWidth && v.y >= 0 && v.y < levelLength) ? true : false;
            bool passable = false;

            if (doesExist)
            {
                passable = graph[(int)v.x, (int)v.y].getCost() < float.PositiveInfinity; // TODO max cost value 
            }

            if (doesExist && passable)
            {
                neighbours.Add(graph[(int)v.x, (int)v.y]);
            }
        }
        return neighbours;
    }

    public float NextMinimumCost(Node n)
    {
        float minCost = float.PositiveInfinity;

        for (int index = 0; index < 8; index++)
        {
            List<Node> neighbours = GetNeighbours(n);
            Vector3 centreNode = n.getNodePos();

            foreach (Node neighbour in neighbours)
            {
                if (neighbour.getCost() < minCost)
                {
                    minCost = neighbour.getCost();
                }
            }
        }
        return minCost + 1;
    }
    
    public void setLevelLength(int newLength)
    {
        this.levelLength = newLength;
    }

    public int getLevelLength()
    {
        return this.levelLength;
    }

    public void setLevelWidth(int newWidth)
    {
        this.levelWidth = newWidth;
    }

    public int getLevelWidth()
    {
        return this.levelWidth;
    }

    // public void setLevelHeight(int newHeight)
    // {
    //     this.levelHeight = newHeight;
    // }

    // public int getLevelHeight()
    // {
    //     return this.levelHeight;
    // }

    public Node[,] getGraph()
    {
        return this.graph;
    }

    public Node GetNode(int posX, int posY)
    {
        return this.graph[posX, posY];
    }
}
