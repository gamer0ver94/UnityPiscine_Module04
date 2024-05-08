using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject projectile;
    private Vector3 direction = Vector3.left;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float delay;
    private float timer = 0;

    void OnTriggerStay2D(Collider2D collider)
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            GameObject newProjectile = Instantiate(projectile,transform.position,Quaternion.identity);
            Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();
            projectileRb.AddForce(direction * Time.deltaTime * speed, ForceMode2D.Impulse);
            timer = 0;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        timer = 0;
    }

}
