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
        PlayerPrefs.SetInt(Constant.SELECTED_SET, (int)setSkinID);
        Set set = DataManager.Ins.GetSet(setSkinID);

        PlayerPrefs.SetInt(Constant.SELECTED_PANT, (int)set.pantSkinID);
        PlayerPrefs.SetInt(Constant.SELECTED_HAT, (int)set.hatSkinID);
        PlayerPrefs.SetInt(Constant.SELECTED_BODY, (int)set.bodyMatID);
        PlayerPrefs.SetInt(Constant.SELECTED_TAIL, (int)set.tailSkinID);
        PlayerPrefs.SetInt(Constant.SELECTED_WING, (int)set.wingSkinID);

        SetShop.Ins.ChooseSet();
    }

}
