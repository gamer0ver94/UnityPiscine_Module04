    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        anim.SetBool("isAttacking", true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        anim.SetBool("isAttacking", false);
    }
}
