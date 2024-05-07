using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float force;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Time.fixedDeltaTime * force,ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(Time.fixedDeltaTime * speed, rb.velocity.y,0);
            isWalking = true;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-Time.fixedDeltaTime * speed, rb.velocity.y,0);
            isWalking = true;
        }
        else{
            isWalking = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
            anim.SetBool("isJumping", false);
            print("collision");
    }

}
