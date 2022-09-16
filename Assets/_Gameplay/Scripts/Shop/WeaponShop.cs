using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    public List<GameObject> weaponShops;

    private int currentWeaponIndex;

    private void Start()
    {
        currentWeaponIndex = 0;
        OpenWeaponShop(weaponShops[0]);
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
}
