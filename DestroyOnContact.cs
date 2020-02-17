using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public GameObject spawn;
    public GameObject explosion;
    private GameController gameController;
    public int PointsValue;
    public int NumEnemies;
    private int MinEnemies;
    



    void Start()
    {       
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void SpawnEnemies()
    {
        Instantiate(spawn, transform.position, transform.rotation);
    }


    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.tag == "Enemy")

        {
            return;
        }

        if (other.gameObject.tag == "Player")

        {
            gameController.AddPoints(PointsValue);            
            gameController.Lives(1);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            
            while (MinEnemies < NumEnemies)
            {
                MinEnemies++;
                SpawnEnemies();
            }
        }        

        if (other.gameObject.tag == "Firerate")

        {
            gameController.AddPoints(PointsValue);
            Destroy(gameObject);

            while (MinEnemies < NumEnemies)                
            {                
                MinEnemies++;
                SpawnEnemies();                
            }            
        }

        if (other.gameObject.tag == "UFO")

        {            
            //Destroy(other.gameObject);
            Destroy(gameObject);           
            

            while (MinEnemies < NumEnemies)
            {
                MinEnemies++;
                SpawnEnemies();
            }
        }


    }
        
}

