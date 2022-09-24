using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PantShopItem : MonoBehaviour
{
    public PantSkinID pantSkinID;
    public GameObject purchaseBtn;

    public void TryPant()
    {
        PantShop.Ins.TryPant(pantSkinID);
    }

    public void ChoosePant()
    {
        PlayerPrefs.SetInt(Constant.SELECTED_PANT, (int)pantSkinID);
        PantShop.Ins.ChoosePant();
    }
}
