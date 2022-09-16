using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewShopManager : MonoBehaviour
{
    public int coins;
    public Text coinText;
    public ShopItemSO[] shopItemSOs;
    public GameObject[] shopPanelsGOs;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;

    private void Start()
    {
        for (int i = 0; i < shopItemSOs.Length; i++)
        {
            shopPanelsGOs[i].SetActive(true);
        }
        coinText.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }

    public void AddCoins()
    {
        coins += 10;
        coinText.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemSOs.Length; i++)
        {
            if (coins >= shopItemSOs[i].baseCose)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemSOs[btnNo].baseCose)
        {
            coins = coins - shopItemSOs[btnNo].baseCose;
            coinText.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
            //Unlock Item

        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemSOs.Length; i++)
        {
            shopPanels[i].titleText.text = shopItemSOs[i].title;
            shopPanels[i].descriptionText.text = shopItemSOs[i].description;
            shopPanels[i].costText.text = "Coins: " + shopItemSOs[i].baseCose.ToString();

        }
    }
}
