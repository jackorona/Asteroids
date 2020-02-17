using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public GameObject explosion;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();       
    }

    /*void OnTriggerEnter2D(Collider2D other)  

    {
        if (other.gameObject.tag == "UFO")

        {
            return;
        }

        if ((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "Firerate"))

        {
            gameObject.SetActive(false);
            Destroy(other.gameObject);            
        }

        if (other.gameObject.tag == "Player")

        {
            gameController.Lives(1);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            gameObject.SetActive(false);
            Destroy(other.gameObject);           
        }

        
    }*/
}
