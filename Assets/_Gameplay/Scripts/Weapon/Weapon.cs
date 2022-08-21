using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weapon;
    public Bullet bulletPrefab;

    public void Attack(Transform charTransform, GameObject charModel)
    {
        Bullet newBullet = Instantiate(bulletPrefab);

        newBullet.SetOriginWeapon(weapon);
        newBullet.SetOriginCharModel(charModel);
        newBullet.SetOriginCharacter(charTransform.gameObject);
        newBullet.SetDirectionVector(charTransform.forward);
        newBullet.transform.position = charTransform.position + Vector3.up * 1f + charTransform.forward * 1f;
    } 
}
