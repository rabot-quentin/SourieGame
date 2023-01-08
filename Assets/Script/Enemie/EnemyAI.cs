using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;

    //partie de la patrol du joueur 
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

 
    public bool Patrol;

    //Partie qui traque le joueur 
    public GameObject Player;
    public float Distance;

    public float Detection;

    public bool isAngered;

    void Start()
    {
      
        Patrol = true; 
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();       
    }
    
    void Update()
    {
        // calcule la distance avec le joueur 
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        //Verifier la distance avec le joueur 
        if (Distance <= Detection)
        {
            isAngered = true;
            Patrol = false;
            Debug.Log("le joueur est en danger");
        }
        if (Distance > Detection)
        {
            isAngered = false;
            Patrol = true;
            UpdateDestination();
            Debug.Log("le joueur est en securiter");
            

        }
        if (Patrol == true)
        {
            if (Vector3.Distance(transform.position, target) < 1)
            {
                IterateWaypointIndex();
                UpdateDestination();
                Debug.Log("ma bite sa marche");
            }
        }
        if(Patrol == false)
        {            
            //Si l'enemie detecte le joueur 
            if (isAngered == true)
            {                
                agent.SetDestination(Player.transform.position);
            }
            //si l'enemie ne detecte plus le joueur 
            if (isAngered == false)
            {
                Patrol = true;
               
                Debug.Log("on reprend la patroulle");
            }
        }
    }
    //Permet de choisir le waypoint ou le garde doit aller 
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
        Debug.Log("on choisi la cible");
       
       
    }
    // Permet de changer de waypoint et reset quand on a finit la liste de waypoint
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
