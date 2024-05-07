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

    private string previousDirection = "Right";
    private bool rightMove = true;

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
            anim.SetFloat("AxisY",1);
        }
        
    }
    void FixedUpdate()
    {
        Flip();
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(Time.fixedDeltaTime * speed, rb.velocity.y,0);
            isWalking = true;
            // Check if need to change Direction of the sprite
            if (rightMove){
                previousDirection = "Right";
                //anim.SetFloat("AxisX",-1);
            }
            anim.SetFloat("AxisX",1);
            rightMove = true;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-Time.fixedDeltaTime * speed, rb.velocity.y,0);
            isWalking = true;
            // Check if need to change Direction of the sprite
            if (!rightMove)
            {
                previousDirection = "Left";
                //anim.SetFloat("AxisX",-1);
            }
            anim.SetFloat("AxisX",1);
            
            rightMove = false;
        }
        else{
            isWalking = false;
            anim.SetFloat("AxisX",0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetFloat("AxisY",0);
        if (collision.collider.gameObject.tag == "Liana")
        {
            anim.SetBool("isAttacked", true);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Liana")
        {
            anim.SetBool("isAttacked", false);
        }
    }

        void Flip()
    {
        if ((rightMove && previousDirection == "Left") || (!rightMove && previousDirection == "Right"))
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
