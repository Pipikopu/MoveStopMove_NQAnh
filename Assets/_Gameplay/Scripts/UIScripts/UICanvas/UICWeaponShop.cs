using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICWeaponShop : UICanvas
{
    public Player player;

    private void OnEnable()
    {
        player.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        player.gameObject.SetActive(true);
    }

    public void ExitWeaponShop()
    {
        UIManager.Ins.OpenUI(UIID.UICMainMenu);
        CinemachineManager.Ins.SwitchToStartGameCam();
        Close();
    }
}