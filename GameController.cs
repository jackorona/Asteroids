using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public GameObject UFO;
    public GameObject smallUFO;
    public GameObject boss;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;
   
   
    public AudioSource BackgroundMusic;


    public Text PointsText;
    public Text restartText;
    public Text gameOverText;
    public Text winText; 

    private bool gameOver;
    private bool restart;
    public bool bossFight;
    private float xSpawn;
    private float ySpawn;
    private int Points;
    
    private int playerLives = 3;
    public float flashTimer = 2.0f;



    private void Awake()
    {
       Points = PlayerPrefs.GetInt("Points");      
       playerLives = PlayerPrefs.GetInt("playerLives");
    }
    void Start()

    {        
        gameOver = false;
        restart = false;         
        winText.text = "";
        gameOverText.text = "";
        restartText.text = "";
        StartCoroutine(UFOSpawn());        
        PointsText.text = "" + Points;

    }
   

    void Update()

    {
        Debug.Log("lives " + playerLives);

        xSpawn = Random.Range(6f, 6.5f);
        ySpawn = Random.Range(4f, -4f);

        if (playerLives == 2) 
        {
            live3.SetActive(false);
        }
        if (playerLives == 1)
        {
            live2.SetActive(false);
        }
        if (playerLives == 0)
        {
            live1.SetActive(false);
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && (GameObject.FindGameObjectsWithTag("UFO").Length == 0 && bossFight == true))
        { 
            StartCoroutine(bossEvent());
        }

           
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && (GameObject.FindGameObjectsWithTag("UFO").Length == 0 && bossFight == false))
        {            
            StartCoroutine(Victory());                       
        }

       
    }
    

    public void AddPoints(int newPointsValue)

    {
        Points += newPointsValue;
        PointsText.text = "" + Points;
    }

    public void Lives(int killed)

    {
        playerLives -= killed;      

        if (playerLives < 1)
        {            
            GameOver();           
        }

        else
        {
            Instantiate(Player, transform.position, transform.rotation);                    
        }
    }

    public void GameOver()
    {                      
        gameOverText.text = "Game Over!           Your score = " + Points;
        restartText.text = "Press R to restart.";       
        gameOver = true;
        restart = true;
    }


    IEnumerator UFOSpawn()
    {       
        
        while (GameObject.FindGameObjectsWithTag("UFO").Length < 6 && GameObject.FindGameObjectsWithTag("Enemy").Length > 2)
        {
            int timeToWait = Random.Range(5, 15);
            int smallUFOtimer = Random.Range(1, 10);
            yield return new WaitForSeconds(timeToWait);            
            if (smallUFOtimer > 7)
            {
                Instantiate(smallUFO, new Vector3(xSpawn, ySpawn, 1), Quaternion.identity);
            }
            else
            { 
                Instantiate(UFO, new Vector3(xSpawn, ySpawn, 0), Quaternion.identity); 
            }         
            
        }
        
    }

    IEnumerator Victory()
    {        
        yield return new WaitForSeconds(1);
        
            winText.text = "You win!";
            yield return new WaitForSeconds(3);
        PlayerPrefs.SetInt("Points", Points);       
        PlayerPrefs.SetInt("playerLives", playerLives);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level 2");
             
    }
    IEnumerator bossEvent()    
    {
            Instantiate(smallUFO, new Vector3(xSpawn +4, ySpawn + 6, 1), Quaternion.identity);
            Instantiate(UFO, new Vector3(xSpawn + 1, ySpawn+ 2, 0), Quaternion.identity);
            Instantiate(boss, new Vector3(xSpawn, ySpawn, 1), Quaternion.identity);
            bossFight = false;
            yield return new WaitForSeconds(1);
    }
}
