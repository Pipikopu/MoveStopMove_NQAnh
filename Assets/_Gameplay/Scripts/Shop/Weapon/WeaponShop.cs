using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : Singleton<WeaponShop>
{
    public List<GameObject> weaponShops;

    private int currentWeaponIndex;

    public Player player;

    private void Start()
    {
        //currentWeaponIndex = 0;
        //OpenWeaponShop(weaponShops[0]);
        Init();
    }

    private void Init()
    {
        int currentWeaponIndex = PlayerPrefs.GetInt("SelectedWeapon");
        OpenWeaponShop(weaponShops[currentWeaponIndex]);

    }

    private void ResetShops()
    {
        foreach(GameObject weaponShop in weaponShops)
        {
            weaponShop.SetActive(false);
        }
    }

    private void OpenWeaponShop(GameObject weaponShop)
    {
        ResetShops();
        weaponShop.SetActive(true);
    }

    public void ChangeNext()
    {
        currentWeaponIndex++;

        if (currentWeaponIndex < weaponShops.Count)
        {
            OpenWeaponShop(weaponShops[currentWeaponIndex]);
        }
        else
        {
            currentWeaponIndex--;
        }
    }

    public void ChangePrev()
    {
        currentWeaponIndex--;

        if (currentWeaponIndex >= 0)
        {
            OpenWeaponShop(weaponShops[currentWeaponIndex]);
        }
        else
        {
            currentWeaponIndex++;
        }
    }

    public void ChooseWeapon()
    {
        player.ChangeWeapon();
    }
}
