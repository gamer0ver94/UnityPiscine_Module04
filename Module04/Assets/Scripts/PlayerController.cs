using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float hp;
    [SerializeField]
    private float speed;
    public float Hp
    {
        get{
            return hp;
        }
    }
    [SerializeField]
    private float force;
    private Rigidbody2D rb;
    private Animator anim;
    private float timer;

    private string previousDirection = "Right";
    private bool rightMove = true;
    public float rayDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && hp > 0 && IsGrounded())
        {
            rb.AddForce(Vector3.up * Time.fixedDeltaTime * force,ForceMode2D.Impulse);
            anim.SetFloat("AxisY",1);
        }
        
    }
    void FixedUpdate()
    {
        if (hp <= 0)
        {
            anim.SetBool("isDead", true);
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                Destroy(this.gameObject);
            }
        }
        Flip();
        if(Input.GetKey(KeyCode.D) && hp > 0)
        {
            rb.velocity = new Vector3(Time.fixedDeltaTime * speed, rb.velocity.y,0);
            // Check if need to change Direction of the sprite
            if (rightMove){
                previousDirection = "Right";
            }
            anim.SetFloat("AxisX",1);
            rightMove = true;
        }
        else if(Input.GetKey(KeyCode.A) && hp > 0)
        {
            rb.velocity = new Vector3(-Time.fixedDeltaTime * speed, rb.velocity.y,0);
            // Check if need to change Direction of the sprite
            if (!rightMove)
            {
                previousDirection = "Left";
            }
            anim.SetFloat("AxisX",1);
            
            rightMove = false;
        }
        else{
            anim.SetFloat("AxisX",0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetFloat("AxisY",0);
        if (collision.collider.gameObject.tag == "Liana" || collision.collider.gameObject.tag == "Cactus")
        {
            anim.SetBool("isAttacked", true);
            hp -= 1;
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

    LayerMask groundLayer;
    bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;


        RaycastHit2D hit = Physics2D.Raycast(position, direction, rayDistance, groundLayer);
        if (hit.collider != null) {
            return true;
        }

        return false;
    }
    private void OnDrawGizmosSelected()
    {
            Gizmos.color = Color.red;
            Vector3 direction = Vector3.down * rayDistance;


            Gizmos.DrawRay(transform.position, direction);
        }
}
