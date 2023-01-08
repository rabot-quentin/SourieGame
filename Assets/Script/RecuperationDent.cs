using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecuperationDent : MonoBehaviour
{
    public GameObject Kevin;
    public int score;
    public TextMeshProUGUI scoreUI;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = score.ToString();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kevin")
        {
            Debug.Log("+1 dent");
            score++;
            Destroy(Kevin.gameObject);
        }
    }
}
