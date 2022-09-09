using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weapon;
    public Bullet bulletPrefab;

    public MeshRenderer meshRend;
    protected WeaponSkinID skinID;

    public virtual void InitSkin(WeaponSkinID SkinID) { }

    public void Attack(Transform charTransform, Character character)
    {
        Bullet newBullet = Instantiate(bulletPrefab);

        newBullet.SetOriginWeapon(weapon);
        newBullet.SetOriginCharacter(character);
        newBullet.SetDirectionVector(charTransform.forward);
        newBullet.InitSkin(skinID);
        newBullet.transform.localScale *= character.GetScale();
        newBullet.transform.eulerAngles += Vector3.up * charTransform.eulerAngles.y;
        newBullet.transform.position = charTransform.position + Vector3.up * 1f + charTransform.forward * 1f;
    }
}
