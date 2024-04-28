using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGraph
{
    private int levelLength;
    private int levelWidth;
    private int levelHeight;

    private Node[,,] graph;

    public LevelGraph(int levelLength, int levelWidth, int levelHeight)
    {
        setLevelLength(levelLength);
        setLevelWidth(levelWidth);
        setLevelHeight(levelHeight);

        graph = new Node[levelLength, levelHeight, levelWidth];

        for (int x = 0; x < levelLength; x++)
        {
            for (int z = 0; z < levelWidth; z++)
            {
                for (int y = 0; y < levelHeight; y++)
                {
                    graph[x, y, z] = new Node(new Vector3(x,z,y), 0); //TODO no cost implementation
                }
            }
        }
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

    public void setLevelHeight(int newHeight)
    {
        this.levelHeight = newHeight;
    }

    public int getLevelHeight()
    {
        return this.levelHeight;
    }

    public Node[,,] getGraph()
    {
        return this.graph;
    }
}
