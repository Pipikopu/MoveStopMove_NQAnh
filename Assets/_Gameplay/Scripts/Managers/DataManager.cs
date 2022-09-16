using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public List<Material> weaponMaterials;

    public Material GetMaterial(WeaponSkinID weaponSkinId)
    {
        switch (weaponSkinId)
        {
            case WeaponSkinID.Hammer_1:
                return weaponMaterials[0];
            case WeaponSkinID.Hammer_2:
                return weaponMaterials[0];
            case WeaponSkinID.Candy0_1:
                return weaponMaterials[0];
            case WeaponSkinID.Candy0_2:
                return weaponMaterials[0];
            case WeaponSkinID.Candy1_1:
                return weaponMaterials[0];
            case WeaponSkinID.Candy2_1:
                return weaponMaterials[0];
            case WeaponSkinID.Axe0:
                return weaponMaterials[0];
            default:
                return null;
        }
    }
}
