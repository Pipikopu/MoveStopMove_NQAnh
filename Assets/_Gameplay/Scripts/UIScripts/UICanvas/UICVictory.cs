using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICVictory : UICanvas
{
    public void NextLevel()
    {
        UIManager.Ins.OpenUI(UIID.UICMainMenu);
        Close();
        LevelManager.Ins.StartGame(PlayerPrefs.GetInt("CurrentLevel") + 1);
    }
}
