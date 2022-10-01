using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICMainMenu : UICanvas
{
    public Player player;
    public Text playerText;
    public Text placeHolderText;

    private void OnEnable()
    {
        placeHolderText.text = PlayerPrefs.GetString("PlayerName", "Player");
        playerText.text = PlayerPrefs.GetString("PlayerName", "Player");
    }

    public void PlayGame()
    {
        UIManager.Ins.OpenUI(UIID.UICGameplay);
        LevelManager.Ins.SetGameState(Constant.GameState.PLAY);
        CinemachineManager.Ins.SwitchToPlayCam();
        Close();
    }

    public void OpenWeaponShop()
    {
        UIManager.Ins.OpenUI(UIID.UICWeaponShop);
        Close();
    }

    public void OpenSkinShop()
    {
        UIManager.Ins.OpenUI(UIID.UICSkinShop);
        CinemachineManager.Ins.SwitchToSkinShopCam();
        Close();
    }

    public void ChangeName()
    {
        string newName = playerText.text;
        PlayerPrefs.SetString("PlayerName", newName);
        player.InitName();
    }
}
