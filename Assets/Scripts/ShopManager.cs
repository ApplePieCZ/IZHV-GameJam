// Script for shop interface
// Author: Lukas Marek
// Date: 22.01.2022
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    private static readonly int[,] ShopItemsKeep = {{0,0,0,0},{0,1,2,3},{0,25,50,200},{0,1,1,1}};
    public float coinsTotal;
    
    public int[,] ShopItems = new int[4,4];
    
    private static float coins;

    public Text coinsTxt;

    public GameObject player;

    public Button[] button;
    public void Awake()
    {
        coinsTxt.text = coins.ToString(CultureInfo.InvariantCulture);
        ShopItems = ShopItemsKeep;
        coinsTotal = coins;
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
                player.GetComponent<Player>().speed += 0.25f;
                ShopItems[2, 1] += 25;
                break;
            case 2:
                player.GetComponent<Player>().shield += 2f;
                player.GetComponent<Player>().actualShield += 2f;
                ShopItems[2, 2] += 50;
                break;
            case 3:
                player.GetComponent<Player>().damage += 1f;
                ShopItems[2, 3] += 100;
                break;
        }

    }
    
    void FixedUpdate()
    {
        coins = coinsTotal;
        coinsTxt.text = coins.ToString(CultureInfo.InvariantCulture);
        if (ShopItems[3, 1] == 15 || coins < ShopItems[2,1])
        {
            button[0].interactable = false;
        }
        if (ShopItems[3, 2] == 20 || coins < ShopItems[2,2])
        {
            button[1].interactable = false;
        }
        if (ShopItems[3, 3] == 5 || coins < ShopItems[2,3])
        {
            button[2].interactable = false;
        }
    }
}
