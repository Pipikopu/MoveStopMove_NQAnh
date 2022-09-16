using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArrow : Weapon
{
    public override void InitSkin(WeaponSkinID skinID)
    {
        //skinID = SkinID;
        //Material weaponSkin = Resources.Load("WeaponSkin/" + SkinID.ToString(), typeof(Material)) as Material;
        Material weaponSkin = DataManager.Ins.GetMaterial(skinID);
        var materials = meshRend.sharedMaterials;
        materials[0] = weaponSkin;
        materials[1] = weaponSkin;
        materials[2] = weaponSkin;
        meshRend.sharedMaterials = materials;
    }
}
