using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit_Control : MonoBehaviour
{
    public GameObject hand;
    public GameObject handCollider; 
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;

    public Image dent; 

    private void Start()
    {
        handCollider.gameObject.SetActive(false);
        dent.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (CanAttack)
            {
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
        dent.gameObject.SetActive(true);
    }

    IEnumerator ResetAttackCooldown ()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        handCollider.gameObject.SetActive(false);
        dent.gameObject.SetActive(false);
    }

}
