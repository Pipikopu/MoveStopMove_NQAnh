using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICFail : UICanvas
{
    public Text rankingText;
    public Text killerName;

    private void OnEnable()
    {
        rankingText.text = "$" + (LevelManager.Ins.GetRemainNumOfBots() + 1).ToString();
        killerName.text = LevelManager.Ins.GetFinalKiller().GetName().ToString();
    }

    public void PlayAgain()
    {
        UIManager.Ins.OpenUI(UIID.UICMainMenu);
        Close();
        LevelManager.Ins.RestartGame();
    }

}
