using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICGameplay : UICanvas
{
    public Text aliveText;

    private void Update()
    {
        aliveText.text = "Alive: " + LevelManager.Ins.GetRemainNumOfBots().ToString();
    }
}
