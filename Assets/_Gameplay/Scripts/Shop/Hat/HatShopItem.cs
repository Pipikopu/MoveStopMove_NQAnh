using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatShopItem : MonoBehaviour
{
    public HatSkinID hatSkinID;
    public GameObject purchaseBtn;

    public void TryHat()
    {
        HatShop.Ins.TryHat(hatSkinID);
    }

    public void ChooseHat()
    {
        PlayerPrefs.SetInt(Constant.SELECTED_HAT, (int)hatSkinID);
        HatShop.Ins.ChooseHat();
    }
}
