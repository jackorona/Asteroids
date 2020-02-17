using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrashMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float random1 = Random.Range(-4f, 4f);
        float random2 = Random.Range(-4f, 4f);
        
        Vector2 movement = new Vector2(random1, random2);
        rb.velocity = movement * speed;
    }
}
