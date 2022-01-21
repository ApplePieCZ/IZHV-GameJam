using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int itemID;

    public Text priceText;

    public Text lvlText;

    public GameObject shopManager;
    
    // Update is called once per frame
    void Update()
    {
        priceText.text = shopManager.GetComponent<ShopManager>().ShopItems[2, itemID].ToString();
        lvlText.text = "Level: " + shopManager.GetComponent<ShopManager>().ShopItems[3, itemID];
    }
}
