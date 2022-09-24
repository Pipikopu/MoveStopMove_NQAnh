using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShopItem : MonoBehaviour
{
    public ShieldSkinID shieldSkinID;

    public GameObject purchaseBtn;

    public void TryShield()
    {
        ShieldShop.Ins.TryShield(shieldSkinID);
    }

    public void ChooseShield()
    {
        PlayerPrefs.SetInt("SelectedShield", (int)shieldSkinID);
        ShieldShop.Ins.ChooseShield();
    }
}
