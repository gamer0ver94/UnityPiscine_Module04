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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Time.fixedDeltaTime * force,ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(Time.fixedDeltaTime * speed, rb.velocity.y,0);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-Time.fixedDeltaTime * speed, rb.velocity.y,0);
        }
    }
}
