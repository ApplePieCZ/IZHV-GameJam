// Script for player movement and behavior
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public Rigidbody2D rb;

    public GameObject bullet;

    Vector2 _movement;

    public GameObject shieldText;

    public float actualShield = 20f;
    
    public float shield = 20f;

    public int damage = 1;

    public bool isDead = false;

    public GameObject shopManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (actualShield <= 0.0f)
        {
            KillPlayer();
            return;
        }
        GetChildNamed(shieldText, "Value").GetComponent<Text>().text = $"{(int) (actualShield)}";
        GetChildNamed(shieldText, "WarningText").SetActive(actualShield <= shield / 100 * 30);
    }

    private void FixedUpdate()
    {
        if (isDead)
        { return; }
        
        // Movement
        if (rb.position.x <= -8.4f && _movement.x == -1f)
        {
            _movement.x = 0;
        }

        if (rb.position.x >= 4.2f && _movement.x == 1f)
        {
            _movement.x = 0;
        }
        
        if (rb.position.y <= -4.4f && _movement.y == -1f)
        {
            _movement.y = 0;
        }

        if (rb.position.y >= 4.4f && _movement.y == 1f)
        {
            _movement.y = 0;
        }
        rb.MovePosition(rb.position + _movement * speed * Time.fixedDeltaTime);
    }

    private void KillPlayer()
    {
        isDead = true;
        GameManager.Instance.LooseGame();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Coin(Clone)")
        {
            shopManager.GetComponent<ShopManager>().coins += 1f;
            return;
        }
        actualShield -= 1.0f;
    }
    
    private static GameObject GetChildNamed(GameObject go, string name) 
    {
        var childTransform = go.transform.Find(name);
        return childTransform == null ? null : childTransform.gameObject;
    }
}