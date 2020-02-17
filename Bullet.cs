using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float direction;
    public float direction2;    

    private Rigidbody2D rb2d;

    void Start()
    {        
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
       
        Destroy(gameObject, lifetime);
    }


    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.gameObject.tag == "Enemy")

        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }       
    }
}
