using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    public int numOfBots;
    private Constant.GameState gameState;

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        gameState = Constant.GameState.PLAY;
    }

    public void DecreaseNumOfBots(int decreaseNum)
    {
        numOfBots -= decreaseNum;
    }

    public int GetRemainNumOfBots()
    {
        return numOfBots;
    }

    public void Win()
    {
        gameState = Constant.GameState.END;
    }

    public void Lose()
    {
        gameState = Constant.GameState.END;
    }

    public Constant.GameState GetGameState()
    {
        return gameState;
    }
}
