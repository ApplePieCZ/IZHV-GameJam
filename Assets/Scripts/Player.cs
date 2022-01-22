// Script for player movement and behavior
// Author: Lukas Marek
// Date: 22.01.2022

using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    public GameObject bullet;

    private Vector2 _movement;

    public GameObject shieldText;

    public float actualShield;

    public float shield;

    public float damage;

    public bool isDead = false;

    public GameObject shopManager;

    private SpriteRenderer _spriteRenderer;

    public Sprite spriteDead;

    public static float[] playerInfo = {5f, 5f, 1f};
    
    // Start is called before the first frame update
    void Start()
    {
        speed = playerInfo[0];
        shield = playerInfo[1];
        damage = playerInfo[2];
        actualShield = shield;
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
        playerInfo[0] = speed;
        playerInfo[1] = shield;
        playerInfo[2] = damage;
        _spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = spriteDead;
        GameManager.Instance.LooseGame();
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