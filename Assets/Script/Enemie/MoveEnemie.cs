using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemie : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;   
    public int damageOnCollision ;

    private Transform target;
    private int destPoint;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
       
    }

    // Update is called once per frame
    void Update()
    {
        float dir = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, dir);


        if (Vector2.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];          

        }

    }
}
