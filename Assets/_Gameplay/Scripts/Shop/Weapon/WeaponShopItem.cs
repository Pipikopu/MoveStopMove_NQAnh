using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopItem : MonoBehaviour
{
    public WeaponID weaponId;

    public WeaponSkinID weaponSkinId;

    public void ChooseWeapon()
    {
        PlayerPrefs.SetInt(Constant.SELECTED_WEAPON, (int)weaponId);
        PlayerPrefs.SetInt(Constant.SELECTED_WEAPON_SKIN, (int)weaponSkinId);
        WeaponShop.Ins.ChooseWeapon();
    }
}