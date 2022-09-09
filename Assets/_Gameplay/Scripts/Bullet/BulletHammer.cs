using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHammer : Bullet
{
    public float rotateSpeed;

    protected override void SpecialMove()
    {
        bulletRenderTransform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public override void InitSkin(WeaponSkinID SkinID)
    {
        Material weaponSkin = Resources.Load("WeaponSkin/" + SkinID.ToString(), typeof(Material)) as Material;
        var materials = meshRend.sharedMaterials;
        materials[0] = weaponSkin;
        materials[1] = weaponSkin;
        meshRend.sharedMaterials = materials;
    }
}
