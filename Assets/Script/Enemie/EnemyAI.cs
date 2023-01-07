using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
       
    }

    
    void Update()
    {
      
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
            Debug.Log("ma bite sa marche"); 
        }
    }
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
        Debug.Log("on choisi la cible");
       
       
    }
    void IterateWaypointIndex()
    {
        waypointIndex += 1 ;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
            Debug.Log("on recomence le tour"); 

        }
    }
}
