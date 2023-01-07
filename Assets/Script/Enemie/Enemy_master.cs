using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Enemy_master : MonoBehaviour
{
    public GameObject Player;
    public float Distance;

    public float Detection ; 

    public bool isAngered;

    public NavMeshAgent _agent; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // calcule la distance avec le joueur 
        Distance = Vector3.Distance(Player.transform.position, this.transform.position); 
        //Verifier la distance avec le joueur 
        if(Distance <= Detection)
        {
            isAngered = true; 
        }
        if(Distance > Detection)
        {
            isAngered = false; 
        }
        //Si l'enemie detecte le joueur 
        if(isAngered)
        {
            _agent.isStopped = false; 
            _agent.SetDestination(Player.transform.position); 
        }
        //si l'enemie ne detecte plus le joueur 
        if(!isAngered)
        {
            _agent.isStopped = true; 
        }
                

    }
}
