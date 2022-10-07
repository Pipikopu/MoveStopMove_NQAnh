using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICSkinShop : UICanvas
{
    public Player player;

    public void OnEnable()
    {
        player.ChooseSkinAnim();    
    }

    public void OnDisable()
    {
        player.ExitSkinAnim();        
    }

    public void ExitSkinShop()
    {
        player.playerSkin.OnInit();
        UIManager.Ins.OpenUI(UIID.UICMainMenu);
        CinemachineManager.Ins.SwitchToStartGameCam();
        Close();
    }
}
