using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public readonly int[,] ShopItems = new int[4,4];
    
    public float coins;

    public Text coinsTxt;

    public GameObject player;

    public Button[] button;
    public void Start()
    {
        coinsTxt.text = coins.ToString(CultureInfo.InvariantCulture);
        // ID's
        ShopItems[1, 1] = 1;
        ShopItems[1, 2] = 2;
        ShopItems[1, 3] = 3;
        // Price
        ShopItems[2, 1] = 25;
        ShopItems[2, 2] = 50;
        ShopItems[2, 3] = 200;
        // Level
        ShopItems[3, 1] = 1; // 10
        ShopItems[3, 2] = 1; // 10
        ShopItems[3, 3] = 1; // 5
        
    }

    public void Buy()
    {
        var buttonReference = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>()
            .currentSelectedGameObject;
        var itemID = buttonReference.GetComponent<ButtonInfo>().itemID;
        
        if (!(coins >= ShopItems[2, itemID])) return;
        
        coins -= ShopItems[2, itemID];
        ShopItems[3, itemID]++;
        coinsTxt.text = coins.ToString(CultureInfo.InvariantCulture);
        buttonReference.GetComponent<ButtonInfo>().lvlText.text = ShopItems[3, itemID].ToString();
            
        switch (itemID)
        {
            case 1:
                player.GetComponent<Player>().speed += 0.5f;
                ShopItems[2, 1] += 25;
                break;
            case 2:
                player.GetComponent<Player>().health += 10f;
                ShopItems[2, 2] += 50;
                break;
            case 3:
                player.GetComponent<Player>().damage += 1;
                ShopItems[2, 3] += 100;
                break;
        }

    }
    
    void FixedUpdate()
    {
        if (ShopItems[3, 1] == 15)
        {
            button[0].interactable = false;
        }
        if (ShopItems[3, 2] == 20)
        {
            button[1].interactable = false;
        }
        if (ShopItems[3, 3] == 5)
        {
            button[2].interactable = false;
        }
    }
}
