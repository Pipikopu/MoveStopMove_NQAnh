using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponID
{
    WeaponHammer = 0,
    WeaponArrow = 1,
    WeaponCandy = 2
}

public enum WeaponSkinID
{
    Hammer_1 = 0,
    Hammer_2 = 1,
    Candy0_1 = 2,
    Candy0_2 = 3,
    Candy1_1 = 4,
    Candy2_1 = 5,
    Axe0 = 6
}

public class WeaponManager : Singleton<WeaponManager>
{
    public Weapon SetWeapon(WeaponID ID, WeaponSkinID SkinID, Transform weaponHolder)
    {
        Weapon weapon = Instantiate(Resources.Load<Weapon>("Weapon/" + ID.ToString()), weaponHolder);
        weapon.InitSkin(SkinID);

        return weapon;
    }
}
