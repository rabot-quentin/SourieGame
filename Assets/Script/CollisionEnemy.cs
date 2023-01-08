using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionEnemy : MonoBehaviour
{
    public string gameOver; 
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("joueur toucher par le garde");
            Destroy(this.gameObject);        
            SceneManager.LoadScene(gameOver);
        }
    }
}
