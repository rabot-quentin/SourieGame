using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hit_Control : MonoBehaviour
{
    
    public GameObject handCollider; 
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;

    public GameObject Kevin;
    public int score;
    public TextMeshProUGUI scoreUI;
    
  // public Image dent;



    private void Start()
    {
        handCollider.gameObject.SetActive(false);
        CanAttack = true;
        //dent.gameObject.SetActive(false);

    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (CanAttack)
            {
               // AudioManager.Instance.PlaySFX("Hit sound");
                handAttack();
            }
        }
    }

    public void handAttack ()
    {
        CanAttack = false;
        //Animator anim = hand.GetComponent<Animator>(); Ajouter l'animation
        //anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
        Debug.Log("Coup de point");
        handCollider.gameObject.SetActive(true);
       
    }


    IEnumerator ResetAttackCooldown ()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        handCollider.gameObject.SetActive(false);
        //dent.gameObject.SetActive(false);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kevin")
        {
            Debug.Log("+1 dent");
          //dent.gameObject.SetActive(true);
            score++;
            Destroy(Kevin.gameObject);
        }
    }

}
