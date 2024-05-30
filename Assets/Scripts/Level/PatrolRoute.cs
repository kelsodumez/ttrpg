using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    [SerializeField] public bool debugDrawGizmo = true;
    [SerializeField] private List<Patrol> patrols;
    private void OnDrawGizmos()
    {
        if (debugDrawGizmo)
        {
                
            Vector3 prevPoint = patrols[0].position;
            foreach (Patrol patrol in patrols)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(prevPoint, patrol.position);
                Gizmos.DrawCube(patrol.position, new Vector3(.8f,.8f,.8f)); 
                prevPoint = patrol.position;
            }
            Gizmos.DrawLine(prevPoint, patrols[0].position);
        }
    }

    public List<Patrol> GetPatrols()
    {
        return patrols;
    }
}

[System.Serializable]
public class Patrol
{
    [SerializeField] private string displayName; // For unity inspector serialiation
    [SerializeField] public Vector3 position;
}