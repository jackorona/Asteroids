using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBullet : MonoBehaviour
{   
    public GameObject explosion;
    private GameController gameController;
    public float lifetime;
    public float direction;
    public float direction2;
    public bool smallUFO = false;
    Vector2 moveDirection;

    private Rigidbody2D rb2d;

    void Start()
    {
        if (transform.position.z > 0) 
        {
            smallUFO = true;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        direction = Random.Range(1f, -1f);
        direction2 = Random.Range(1f, -1f);
        rb2d = GetComponent<Rigidbody2D>();        
        GameObject player = GameObject.FindWithTag("Player");
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();

        if (smallUFO == true && GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            moveDirection = (player.transform.position - transform.position).normalized * 5;
            rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
            Destroy(gameObject, lifetime);
        }

        else 
        {
            rb2d.velocity = new Vector2(direction, direction2) * 10;
            Destroy(gameObject, lifetime);
        }
          
        
        Destroy(gameObject, lifetime);

           
    }


    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.gameObject.tag == "Enemy")

        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")

        {
            gameController.Lives(1);
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }
    }
}
