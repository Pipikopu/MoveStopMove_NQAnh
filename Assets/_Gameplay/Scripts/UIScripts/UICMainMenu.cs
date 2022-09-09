using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICMainMenu : UICanvas
{
    public void PlayGame()
    {
        UIManager.Ins.OpenUI(UIID.UICGameplay);
        LevelManager.Ins.SetGameState(Constant.GameState.PLAY);
        Close();
    }
}
