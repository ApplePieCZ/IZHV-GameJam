// Script for updating button info
// Author: Lukas Marek
// Date: 22.01.2022
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int itemID;

    public Text priceText;

    public Text lvlText;

    public GameObject shopManager;
    
    void Update()
    {
        priceText.text = shopManager.GetComponent<ShopManager>().ShopItems[2, itemID].ToString();
        lvlText.text = "Level: " + shopManager.GetComponent<ShopManager>().ShopItems[3, itemID];
    }
}
