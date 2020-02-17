using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{

    public Camera camera;
    public float deadZone;


    void Start()
    {
        camera = Camera.main;
        deadZone = 1.0f;   
    }

    void Update()
    {

        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        bool leftScreen = false;
        float new_x = transform.position.x;
        float new_y = transform.position.y;
        if (transform.position.x <= bottomLeft.x - deadZone)
        {
            new_x = topRight.x;
            leftScreen = true;
        }

        if (transform.position.x >= topRight.x + deadZone)
        {

            new_x = bottomLeft.x;

            leftScreen = true;

        }

        if (transform.position.y <= bottomLeft.y - deadZone)
        {

            new_y = topRight.y;

            leftScreen = true;

        }

        if (transform.position.y >= topRight.y + deadZone)
        {

            new_y = bottomLeft.y;
            leftScreen = true;
        }

        if (leftScreen)
        {

            transform.position = new Vector3(new_x, new_y, transform.position.z);

        }

    }

}
