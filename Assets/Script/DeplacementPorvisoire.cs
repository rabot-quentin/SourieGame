using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPorvisoire : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 15);


        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 15);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 15);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 15);

        }
    }


}
