using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Renderer charRend;

    public int currentPantIndex;
    public PantItem[] pantSkins;
    public PantBlueprint[] pantBlueprints;
    public Button buyButton;
    public Text buyButtonText;

    public int coinNum = 150;

    private void Start()
    {
        foreach(PantBlueprint pantBlueprint in pantBlueprints)
        {
            if (pantBlueprint.price == 0)
                pantBlueprint.isUnlocked = true;
            else
                pantBlueprint.isUnlocked = PlayerPrefs.GetInt(pantBlueprint.name, 0)==0 ? false : true;
        }

        currentPantIndex = PlayerPrefs.GetInt("SelectedPant", 0);
        foreach(PantItem pant in pantSkins)
        {
            pant.gameObject.SetActive(false);
        }

        pantSkins[currentPantIndex].gameObject.SetActive(true);
        ChangeSkinMat();
    }


    private void Update()
    {
        UpdateUI();
    }

    public void ChangeNext()
    {
        pantSkins[currentPantIndex].gameObject.SetActive(false);

        currentPantIndex++;

        if (currentPantIndex == pantSkins.Length)
            currentPantIndex = 0;

        pantSkins[currentPantIndex].gameObject.SetActive(true);

        ChangeSkinMat();

        PantBlueprint p = pantBlueprints[currentPantIndex];
        if (!p.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedPant", currentPantIndex);
    }
    
    public void ChangePrev()
    {
        pantSkins[currentPantIndex].gameObject.SetActive(false);

        currentPantIndex--;

        if (currentPantIndex == -1)
            currentPantIndex = pantSkins.Length - 1;

        pantSkins[currentPantIndex].gameObject.SetActive(true);

        ChangeSkinMat();

        PantBlueprint p = pantBlueprints[currentPantIndex];
        if (!p.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedPant", currentPantIndex);
    }

    private void UpdateUI()
    {
        PantBlueprint p = pantBlueprints[currentPantIndex];

        if (p.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            if (p.price <= coinNum)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
            buyButtonText.text = "Buy - " + p.price;
        }
    }

    public void UnlockPant()
    {
        PantBlueprint p = pantBlueprints[currentPantIndex];

        PlayerPrefs.SetInt(p.name, 1);
        PlayerPrefs.SetInt("SelectedPant", currentPantIndex);

        p.isUnlocked = true;
        coinNum -= p.price;
    }

    private void ChangeSkinMat()
    {
        var materials = charRend.sharedMaterials;
        materials[0] = pantSkins[currentPantIndex].GetMaterial();
        charRend.sharedMaterials = materials;
    }

    public void ResetStore()
    {
        foreach (PantBlueprint pantBlueprint in pantBlueprints)
        {
            if (pantBlueprint.price == 0)
                pantBlueprint.isUnlocked = true;
            else
            {
                pantBlueprint.isUnlocked = false;
                PlayerPrefs.SetInt(pantBlueprint.name, 0);
            }

        }
    }
}
