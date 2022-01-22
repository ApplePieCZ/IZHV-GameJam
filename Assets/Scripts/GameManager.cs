using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float currentScore = 0.0f;
    
    public GameObject startText;

    public GameObject lossText;
    
    public GameObject scoreText;
    
    public GameObject player;
    
    public GameObject spawner;
    
    private bool mGameLost = false;

   
    private static bool sGameStarted = false;
    public static GameManager Instance
    { get { return sInstance; } }
    
    private static GameManager sInstance;
    
    private void Awake()
    {
        if (sInstance != null && sInstance != this)
        { Destroy(gameObject); }
        else
        { sInstance = this; }
        SetupGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Start the game after the first "Jump".
        if (!sGameStarted && Input.GetButtonDown("Jump"))
        { StartGame(); }
        
        // Reset the game if requested.
        if (Input.GetButtonDown("Cancel"))
        { ResetGame(); }

        if (sGameStarted && !mGameLost)
        {
            currentScore += Time.deltaTime;
            GetChildNamed(scoreText, "Value").GetComponent<Text>().text = $"{(int) (currentScore)}";
        }
    }
    
    public void SetupGame()
    {
        
        if (sGameStarted)
        { // Setup already started game -> Retry.
            startText.SetActive(false);
            scoreText.SetActive(true);
            lossText.SetActive(false);
        }
        else
        { 
            // Don't start spawning until we start.
            
            // Setup the text.
            startText.SetActive(true);
            scoreText.SetActive(false);
            lossText.SetActive(false);
        }
        mGameLost = false;
    }
    
    public void StartGame()
    {
        // Reload the scene as started.
        sGameStarted = true; 
        ResetGame();
    }
    
    public void ResetGame()
    {
        // Reload the active scene, triggering reset...
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LooseGame()
    {
        // Get the spawner script.
        //var sp = spawner.GetComponent<Spawner>();
        // Stop the obstacles.
        //sp.ModifyObstacleSpeed(0.0f);
        // Stop spawning.
        //sp.spawnObstacles = false;
        // Show the loss text.
        lossText.SetActive(true);
        // Loose the game.
        mGameLost = true;
    }
    
    private static GameObject GetChildNamed(GameObject go, string name) 
    {
        var childTransform = go.transform.Find(name);
        return childTransform == null ? null : childTransform.gameObject;
    }
}
