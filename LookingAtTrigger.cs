using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    Transform Npc;

    [Range(0, 5)]
    public float radius = 1;

    [Tooltip("How strictly should the lookingAt trigger be. 0 is the least 1 is the most.)")]
    [Range(0, 1)]
    public float threshold = 1;


    private void OnDrawGizmos()
    {
        Vector3 dir = Npc.position - transform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + dir.normalized);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward.normalized);

        float dotP = Vector3.Dot(dir.normalized, transform.forward.normalized);
        Debug.Log(dotP);

        if(dotP >= threshold)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
        
       
    }
}
