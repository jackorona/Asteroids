using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
          
    public float thrust = 5;
    public float rotationSpeed = 5;
    public float nextFire = 5;
    public float fireRate = 5;
    public GameObject shot;
    public GameObject thurst;
    public AudioSource Laseraudio;
    public AudioClip Laser;     


    public Transform shotSpawn;
    private bool canMove;
    private bool canTeleport;
    public float xTeleport;
    public float yTeleport;

    private Rigidbody2D rb2d;  

    void Start()
    {
        canMove = false;
        canTeleport = false;
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(Invincible(3.0f));
    }   
    
    void Update()
    {
        xTeleport = Random.Range(6f, -6f);
        yTeleport = Random.Range(4f, -4f);

        if (canMove == true)
        {
            transform.Rotate(0, 0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
            rb2d.AddForce(transform.up * thrust * Input.GetAxis("Up"));

            if (Input.GetButton("Up"))
            {
                thurst.SetActive(true);
            }
            else 
            { 
                thurst.SetActive(false); 
            }
            if (Input.GetButtonDown("Jump") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                Laseraudio.clip = Laser;
                Laseraudio.Play();
            }            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canTeleport == true)
        {
            StartCoroutine(teleport());            
        }        
    }

    IEnumerator Invincible(float waitTime)// Invincible timer
    {
        int a = 0;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        GetComponent<Transform>().position = new Vector2(0.0f, 0.0f);
        yield return new WaitForSeconds(0.7f);        
        canMove = true;
        canTeleport = true;

        while (a < 10)
        {
            a++;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<BoxCollider2D>().enabled = true;        
    }


    IEnumerator teleport() 
    {
        canMove = false;
        canTeleport = false;
        rb2d.velocity = new Vector2(0, 0);
        transform.position = new Vector2(xTeleport, yTeleport);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(0.7f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
        canTeleport = true;
        canMove = true;        
    }
}
