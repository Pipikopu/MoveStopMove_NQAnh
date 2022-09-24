using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponID
{
    WeaponHammer = 0,
    WeaponCandy = 1,
    WeaponArrow = 2,
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

public enum PantSkinID
{
    no_pant = 0,
    comy = 1,
    dabao = 2,
    onion = 3,
    evil_set = 4,
}

public enum HatSkinID
{
    no_hat = 0,
    arrow = 1,
    crown = 2,
    ear = 3,
    flower = 4,
    hair = 5,
    hat_cap = 6,
    headphone = 7,
    horn = 8,
    rau = 9
}

public enum ShieldSkinID
{
    no_shield = 0,
    black = 1,
    captain = 2
}

public enum BodyMaterialID
{
    Green,
    Red,
    Blue,
    Yellow,
    Pink,
    Purple,
    Orange
}

public enum TailSkinID
{
    no_tail,
    tail_evil_set
}

public enum WingSkinID
{
    no_wing,
    wing_evil_set
}

public enum SetSkinID
{
    no_set = 0,
    evil_set = 1,
}

public class PrefabManager : Singleton<PrefabManager>
{
    public Weapon SetWeapon(WeaponID ID, WeaponSkinID SkinID, Transform weaponHolder)
    {
        Weapon weapon = Instantiate(DataManager.Ins.GetWeapon(ID), weaponHolder);
        weapon.InitSkin(SkinID);

        return weapon;
    }

    public Item SetHat(HatSkinID ID, Transform hatHolder)
    {
        if (DataManager.Ins.GetHatItem(ID) != null)
        {
            Item hat = Instantiate(DataManager.Ins.GetHatItem(ID), hatHolder);
            return hat;
        }
        return null;
    }

    public Item SetShield(ShieldSkinID ID, Transform shieldHolder)
    {
        if (DataManager.Ins.GetShieldItem(ID) != null)
        {
            Item shield = Instantiate(DataManager.Ins.GetShieldItem(ID), shieldHolder);
            return shield;
        }

        return null;
    }

    public Item SetTail(TailSkinID ID, Transform tailHolder)
    {
        if (DataManager.Ins.GetTailItem(ID) != null)
        {
            Item tail = Instantiate(DataManager.Ins.GetTailItem(ID), tailHolder);
            return tail;
        }
        return null;
    }

    public Item SetWing(WingSkinID ID, Transform wingHolder)
    {
        if (DataManager.Ins.GetWingItem(ID) != null)
        {
            Item wing = Instantiate(DataManager.Ins.GetWingItem(ID), wingHolder);
            return wing;
        }
        return null;
    }
}

