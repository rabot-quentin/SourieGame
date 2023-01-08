using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuperationDent : MonoBehaviour
{
    public GameObject Kevin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kevin")
        {
            Debug.Log("+1 dent");
            Destroy(Kevin.gameObject);
        }
    }
}
