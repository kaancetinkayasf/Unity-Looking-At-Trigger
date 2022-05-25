using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
    [SerializeField]
    Transform Npc;

    [Tooltip("Just a debug sphere to illustrate the lookingAtTrigger")]
    [Range(0, 5)]
    public float radius = 1;

    [Tooltip("How strictly the lookingAt trigger should be. 0 is the least 1 is the most. If the treshold is 0, the player can still see the npc even the player's local forward direction is perpendicular to the direction between player and the npc. If its 1 it means the player's local forward direction and the direction between the player and the npc must be pointing at the exact same direction. " +
        "Note: If you wanna get the standard 60 degree view, set this value to 0.5f)")]
    [Range(0, 1)]
    public float threshold = 1;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        //Remove the OnDrawGizmos if you do not want to visualize what is happening.

        Vector3 dir = Npc.position - transform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + dir.normalized);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward.normalized);

        float dotP = HowStraightXLookingAtY(transform, Npc);
        

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
#endif

    /// <summary>
    /// Returns a value beween 0 and 1.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    float HowStraightXLookingAtY(Transform x,Transform y)
    {
        Vector3 dir = y.position - x.position;
        float dotP = Vector3.Dot(x.forward.normalized, dir.normalized);
  

        return dotP;

    }

    private void Update()
    {
        float dotP = HowStraightXLookingAtY(transform, Npc);

        if (dotP >= threshold)
        {
            // In the range of player. The if block's value depends on the threshold value. If the treshold is 0, the player can still see the npc even the player's local forward direction is perpendicular to the direction between player and the npc.
            Debug.Log("Player can see the NPC");
        }

        else
        {
            // Out of the range of the player
            Debug.Log("Player can't the see NPC");
        }
    }

}
