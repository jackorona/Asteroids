using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Objects : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;


    void Start()
    {
        float random1 = Random.Range(-4f, 4f);
        float random2 = Random.Range(-4f, 4f);
        float random3 = Random.Range(-4f, 4f);

        rb = GetComponent<Rigidbody>();            
        Vector3 movement = new Vector3(random1, random2, 0);
        rb.velocity = movement * speed;
        rb.angularVelocity = Random.insideUnitSphere * random3;   
    }

     void Update()
    {
        
    }

    void FixedUpdate()
    {

    }
}
