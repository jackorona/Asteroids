using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBubble : MonoBehaviour {


    public float min = 1f;
    public float max = 10f;
    public float speed = 1f;
    // Use this for initialization
    void Start()
    {

        min = transform.position.y;
        max = transform.position.y + 10;

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3( transform.position.x, Mathf.PingPong(Time.time * speed, max - min) + min,transform.position.z);

    }

}


