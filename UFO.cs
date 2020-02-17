using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    bool canShoot = true;
    bool canMove = true;
    public int PointsValue;
    public int randomDirection;
    public float speed = 2.0f;     
    private Rigidbody2D rb2d;
    private SpriteRenderer mySpriteRenderer;

    public GameObject shot;
    public GameObject explosion;     

    private GameController gameController;


    private void Awake()
    {
        randomDirection = Random.Range(1, 3);
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
        if (randomDirection == 2)
        {
            speed *= -1;
            mySpriteRenderer.flipX = true;
        }
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;   
        

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }        
    }

    public void Update()   
    {
        if (canMove == true) 
        {
            StartCoroutine(Moveto());
        }

        if (canShoot == true)
        {
            StartCoroutine(Shoot());
        }

        Debug.Log("speed" + speed);
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.9f);
        Instantiate(shot, transform.position, transform.rotation);    
        canShoot = true;
    } 
    IEnumerator Moveto()
    {
        canMove = false;
        int MoveDirection = Random.Range(3, -3);
        int timeToWait = Random.Range(3, 8);     
        while (timeToWait > 0)
        {
            timeToWait--;
            yield return new WaitForSeconds(1f);           
        }        
        rb2d.AddForce(new Vector2(0, MoveDirection), ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        rb2d.velocity = new Vector2(speed, 0);
        canMove = true;
    }

    void OnTriggerEnter2D(Collider2D other)

    {

        if (other.gameObject.tag == "Enemy")

        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }

        if (other.gameObject.tag == "Firerate")

        {
            gameController.AddPoints(PointsValue);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }

        if (other.gameObject.tag == "Player")

        {
            gameController.Lives(1);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);            
        }
    }
}
