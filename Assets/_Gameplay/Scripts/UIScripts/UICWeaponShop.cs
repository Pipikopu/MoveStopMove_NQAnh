using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICWeaponShop : UICanvas
{
    public void ExitWeaponShop()
    {
        UIManager.Ins.OpenUI(UIID.UICMainMenu);
        Close();
    }
}
