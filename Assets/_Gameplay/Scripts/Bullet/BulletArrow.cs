using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArrow : Bullet
{
    public List<MeshRenderer> meshRends;

    protected override void SpecialMove() { }

    public override void InitSkin(WeaponSkinID skinID)
    {
        for (int i = 0; i < meshRends.Count; i++)
        {
            //Material weaponSkin = Resources.Load("WeaponSkin/" + SkinID.ToString(), typeof(Material)) as Material;
            Material weaponSkin = DataManager.Ins.GetMaterial(skinID);
            var materials = meshRends[i].sharedMaterials;
            materials[0] = weaponSkin;
            materials[1] = weaponSkin;
            materials[2] = weaponSkin;
            meshRends[i].sharedMaterials = materials;
        }
    }
}
