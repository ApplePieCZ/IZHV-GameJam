// Script for managing the game
// Author: Lukas Marek
// Date: 22.01.2022
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
    
    public GameObject[] spawner;

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
            
            StartSpawning();
        }
        else
        { 
            // Don't start spawning until we start.
            StopSpawning();
            // Setup the text.
            startText.SetActive(true);
            scoreText.SetActive(false);
            lossText.SetActive(false);
        }
        mGameLost = false;
    }
    
    public void StartGame()
    {
        sGameStarted = true; 
        ResetGame();
    }
    
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartSpawning();
    }
    
    public void LooseGame()
    {
        StopSpawning();
        
        lossText.SetActive(true);
        
        mGameLost = true;
    }
    
    private static GameObject GetChildNamed(GameObject go, string name) 
    {
        var childTransform = go.transform.Find(name);
        return childTransform == null ? null : childTransform.gameObject;
    }

    private void StopSpawning()
    {
        spawner[0].GetComponent<Spawner>().spawn = false;
        spawner[1].GetComponent<EnemyPassiveMasterSpawner>().spawn = false;
    }

    private void StartSpawning()
    {
        spawner[0].GetComponent<Spawner>().spawn = true;
        spawner[1].GetComponent<EnemyPassiveMasterSpawner>().spawn = true;
    }
}
