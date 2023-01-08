using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class KevineIa : MonoBehaviour
{
    NavMeshAgent navAgent;

    public Transform[] waypointsKev;
    int waypointIndexKev;
    Vector3 targetKev;

    
    // Start is called before the first frame update
    
    public void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        UpdateDestinationKev();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetKev) < 1)
        {
            IterateWaypointIndexKev();
            UpdateDestinationKev();
        }
    }
    void UpdateDestinationKev()
    {
        targetKev = waypointsKev[waypointIndexKev].position;
        navAgent.SetDestination(targetKev);
        Debug.Log("on choisi la cible");


    }
    // Permet de changer de waypoint et reset quand on a finit la liste de waypoint
    void IterateWaypointIndexKev()
    {
        waypointIndexKev += 1;
        if (waypointIndexKev == waypointsKev.Length)
        {
            waypointIndexKev = 0;
            Debug.Log("on recomence le tour");

        }
    }

}
