using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItem[] shopItems;
    public GameObject[] shopPanels;
    public ShopTemplate[] shopTemplate;
    public Button[] purchaseButton;
    public Inventory playerInventory;

    void Start()
    {
        //playerInventory = GameObject.Find("Inventory").GetComponent<Inventory>();


        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].SetActive(true);
            coinUI.text = "Coins: " + coins.ToString();
            LoadPanels();
            CheckPurchaseable();
        }

        if (playerInventory == null)
        {
            Debug.LogError("Player Inventory is not assigned in the Market script.");
        }

        if (shopItems == null || shopItems.Length == 0)
        {
            Debug.LogError("Market items are not assigned or empty in the Market script.");
        }
    }

    void Update()
    {

    }

    public void AddCoins()
    {
        coins++;
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (coins >= shopItems[i].baseCost)
                purchaseButton[i].interactable = true;

            else
                purchaseButton[i].interactable = false;
        }
    }

    public void CheckPurchaseItem(int btnNo)
    {
        if (coins >= shopItems[btnNo].baseCost)
        {
            coins = coins - shopItems[btnNo].baseCost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopTemplate[i].ItemTitle.text = shopItems[i].title;
            shopTemplate[i].ItemDescription.text = shopItems[i].description;
            shopTemplate[i].ItemPrice.text = "Coins: " + shopItems[i].baseCost.ToString();
        }
    }

    public void BuyItem(int itemIndex)
    {

        if (itemIndex >= 0 && itemIndex < shopItems.Length)
        {
            ShopItem itemToBuy = shopItems[itemIndex];
            playerInventory.AddItem(itemToBuy);
            Debug.Log("Purchased item: " + itemToBuy.title);
        }

        else if(playerInventory == null)
        {
            Debug.LogError("Player Inventory is not assigned.");
            return;
        }

        else
        {
            Debug.Log("Invalid item index");
        }
    }

}
