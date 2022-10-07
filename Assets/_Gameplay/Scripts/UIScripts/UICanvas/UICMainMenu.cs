using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICMainMenu : UICanvas
{
    public Player player;
    public Text playerText;
    public Text placeHolderText;
    public Image progressFill;
    public List<Sprite> levelSprites;
    public Image levelIcon;

    private void OnEnable()
    {
        placeHolderText.text = PlayerDataController.Ins.LoadFromJson().name;
        playerText.text = PlayerDataController.Ins.LoadFromJson().name;
        progressFill.rectTransform.localScale = new Vector3(PlayerDataController.Ins.LoadFromJson().progress, 1, 1);
        int level = PlayerDataController.Ins.LoadFromJson().level;
        if (level >= levelSprites.Count) level = 0;
        levelIcon.sprite = levelSprites[level];
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
        PlayerData data = PlayerDataController.Ins.LoadFromJson();
        data.name = newName;
        PlayerDataController.Ins.SaveToJson(data);
        player.InitName();
    }


}
