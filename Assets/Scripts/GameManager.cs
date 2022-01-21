using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float currentScore = 0.0f;
    
    private bool celebration25 = true;
    
    private bool celebration50 = true;
    
    private bool celebration100 = true;
    
    public GameObject startText;

    public GameObject lossText;
    
    public GameObject scoreText;
    
    public GameObject player;
    
    public GameObject spawner;
    
    private static float allTimeHigh = 0.0f;
    
    
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
            // Increment the score by elapsed time.
            currentScore += Time.deltaTime;
            // Celebrations on few important values
            if (currentScore > 25000.0f && celebration25)
            {
                FindObjectOfType<AudioManager>().Play("Celeb25");
                celebration25 = false;
            }
            if (currentScore > 50000.0f && celebration50)
            {
                FindObjectOfType<AudioManager>().Play("Celeb50");
                celebration50 = false;
            }
            if (currentScore > 100000.0f && celebration100)
            {
                FindObjectOfType<AudioManager>().Play("Celeb100");
                celebration100 = false;
            }
            // Update the score text.
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
        { // Setup a new game -> Wait for start.
            // Don't start spawning until we start.
            
            // Setup the text.
            startText.SetActive(true);
            scoreText.SetActive(false);
            lossText.SetActive(false);
        }
        
        // Set the state.
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
    
    private static GameObject GetChildNamed(GameObject go, string name) 
    {
        var childTransform = go.transform.Find(name);
        return childTransform == null ? null : childTransform.gameObject;
    }
}
