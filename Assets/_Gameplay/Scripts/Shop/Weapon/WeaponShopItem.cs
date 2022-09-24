using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopItem : MonoBehaviour
{
    public WeaponID weaponId;

    public WeaponSkinID weaponSkinId;

    public void ChooseWeapon()
    {
        PlayerPrefs.SetInt("SelectedWeapon", (int)weaponId);
        PlayerPrefs.SetInt("SelectedWeaponSkin", (int)weaponSkinId);
        WeaponShop.Ins.ChooseWeapon();
    }
}