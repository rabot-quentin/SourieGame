using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Control : MonoBehaviour
{
    public GameObject hand;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;

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
    }

    IEnumerator ResetAttackCooldown ()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

}
