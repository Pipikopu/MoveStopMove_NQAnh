using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShopItem : MonoBehaviour
{
    public SetSkinID setSkinID;

    public GameObject purchaseBtn;

    public void TrySet()
    {
        SetShop.Ins.TrySet(setSkinID);
    }

    public void ChooseSet()
    {
        PlayerPrefs.SetInt("SelectedSet", (int)setSkinID);
        Set set = DataManager.Ins.GetSet(setSkinID);
        PlayerPrefs.SetInt("SelectedPant", (int)set.pantSkinID);
        PlayerPrefs.SetInt("SelectedHat", (int)set.hatSkinID);
        PlayerPrefs.SetInt("SelectedBody", (int)set.bodyMatID);
        PlayerPrefs.SetInt("SelectedTail", (int)set.tailSkinID);
        PlayerPrefs.SetInt("SelectedWing", (int)set.wingSkinID);
        SetShop.Ins.ChooseSet();
    }

}
