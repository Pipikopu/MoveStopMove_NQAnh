using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCandy : Weapon
{
    public override void InitSkin(WeaponSkinID SkinID)
    {
        skinID = SkinID;
        Material weaponSkin = Resources.Load("WeaponSkin/" + SkinID.ToString(), typeof(Material)) as Material;
        var materials = meshRend.sharedMaterials;
        materials[0] = weaponSkin;
        materials[1] = weaponSkin;
        materials[2] = weaponSkin;
        meshRend.sharedMaterials = materials;
    }
}
